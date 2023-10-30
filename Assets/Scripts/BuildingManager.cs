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

    [Header("Anim Options")]
    [SerializeField] private float waitTime;



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
            BuildingAnim();
            startAnimation = false;
        }    
    }

    private async Task BuildingAnim()
    {
        for (int i = 0; i < buildParts.Length; i++)
        {
            buildParts[i].gameObject.SetActive(true);
            buildParts[i].GoTargetPos();
            await Task.Delay((int)waitTime * 1000);
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
