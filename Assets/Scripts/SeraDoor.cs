using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SeraDoor : MonoBehaviour
{
    [SerializeField] private BuildPart[] seraPlantParts;
    [SerializeField] private GameObject hologram;
    private bool animCompleted;


    private void OnTriggerEnter(Collider other)
    {
        if (!animCompleted && other.gameObject.TryGetComponent(out LocomotionSystem loc))
        {
            StartCoroutine(SeraPlantAnim());
            animCompleted = true;
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
}
