using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private bool savePartTransforms;
    [SerializeField] private BuildPart[] buildParts;
    [SerializeField] private bool startAnimation;
    [SerializeField] private GameObject[] explodeParts;
    [SerializeField] private GameObject lastPipes;
    [SerializeField] private GameObject door;

    [Header("Anim Options")]
    [SerializeField] private float waitTime;
    [SerializeField] private MainPart part;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    private void Start()
    {
        if (savePartTransforms)
        {
            foreach (BuildPart part in buildParts)
            {
                part.GetBuildPartData().defaultPosition = part.transform.localPosition;
            }
        }

    }


    private void Update()
    {
        if (startAnimation)
        {
            StartCoroutine(BuildingAnim());
            startAnimation = false;
        }    
    }

    private IEnumerator BuildingAnim()
    {
        for (int i = 0; i < buildParts.Length; i++)
        {
            if (buildParts[i].GetBuildPartData() != null)
            {
                buildParts[i].gameObject.SetActive(true);
                buildParts[i].GoTargetPos();
                if (!buildParts[i].TryGetComponent(out MainPart mainPart))
                {
                    yield return new WaitForSeconds(buildParts[i].GetBuildPartData().waitTime);
                }
                else
                {
                    yield return new WaitUntil(() => part.GetCompleted());
                    lastPipes.SetActive(true);
                    lastPipes.transform.DOLocalMove(Vector3.zero, 1f);
                }
            }
            else
            {
                StartCoroutine(ExplodeAnim());
            }
        }
        door.transform.DOScale(1f, 1f).SetDelay(1f);
        
    }

    private IEnumerator ExplodeAnim()
    {
        foreach(GameObject part in explodeParts)
        {
            Vector3 firstPos = part.transform.localPosition;
            Vector3 firstRot = part.transform.localEulerAngles;

            part.transform.localPosition += new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
            part.transform.localEulerAngles += new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
            part.SetActive(true);

            part.transform.DOLocalMove(firstPos, 0.75f);
            part.transform.DOLocalRotate(firstRot, 0.75f);

            yield return new WaitForSeconds(0.025f);
        }
    }


    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void StartAnim()
    {
        startAnimation = true;
    }

}
