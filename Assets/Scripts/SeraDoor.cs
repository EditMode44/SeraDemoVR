using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SeraDoor : MonoBehaviour
{
    [SerializeField] private BuildPart[] seraPlantParts;
    [SerializeField] private GameObject[] boxes;
    [SerializeField] private GameObject hologram;
    [SerializeField] private GameObject plantingBasketsParent;
    [SerializeField] private GameObject seedsParent;
    private bool animCompleted;
    private bool boxCompleted;


    private void Update()
    {
        if (!animCompleted && BuildingManager.instance.GetTeleportComplete())
        {
            Invoke(nameof(Anim), 1f);
            animCompleted = true;
        }


        if (boxCompleted)
        {
            plantingBasketsParent.SetActive(true);
            seedsParent.SetActive(true);
            boxCompleted = false;
        }
    }

    private IEnumerator SeraPlantAnim()
    {
        foreach (BuildPart part in seraPlantParts)
        {
            part.gameObject.SetActive(true);
            part.GoTargetPos();
            yield return new WaitForSeconds(part.GetBuildPartData().waitTime);
        }
        hologram.transform.DOScale(0f, 0f).SetDelay(0.75f);
    }


    private void Anim()
    {
        foreach (GameObject box in boxes)
        {
            box.transform.DOScale(1f, 0.5f).OnComplete(() => boxCompleted = true);
        }
        StartCoroutine(SeraPlantAnim());
    }
}
