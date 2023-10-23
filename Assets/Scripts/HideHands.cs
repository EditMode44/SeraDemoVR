using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HideHands : MonoBehaviour
{
    [SerializeField] private GameObject handModel;


    public void DisableHandModel(SelectEnterEventArgs arg)
    {
        if (arg.interactableObject.transform.GetComponent<InteractableInfo>().interactableType == InteractableInfo.InteractableType.HideHands)        {
            arg.interactableObject.transform.GetComponent<InteractableInfo>().handModel.SetActive(true);
            handModel.SetActive(false);
        }
    }

    public void EnableHandModel(SelectExitEventArgs arg)
    {
        if (arg.interactableObject.transform.GetComponent<InteractableInfo>().interactableType == InteractableInfo.InteractableType.HideHands)
        {
            arg.interactableObject.transform.GetComponent<InteractableInfo>().handModel.SetActive(false);
            handModel.SetActive(true);
        }
    }
}
