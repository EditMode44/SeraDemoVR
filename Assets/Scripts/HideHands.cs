using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HideHands : MonoBehaviour
{
    [SerializeField] private GameObject handModel;
    [SerializeField] private XRDirectInteractor interactor;
    [SerializeField] private XRDirectInteractor baseHand;

    public enum HandType
    {
        Left,
        Right
    }

    public HandType handType;


    public void DisableHandModel(SelectEnterEventArgs arg)
    {
        if (arg.interactableObject.transform.GetComponent<InteractableInfo>().interactableType == InteractableInfo.InteractableType.HideHands)    
        {
            if (handType == HandType.Left)
            {
                arg.interactableObject.transform.GetComponent<InteractableInfo>().GetLeftHand().SetActive(true);
            }
            else
            {
                arg.interactableObject.transform.GetComponent<InteractableInfo>().GetRightHand().SetActive(true);
            }

            interactor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.StateChange;
            if (arg.interactableObject.transform.TryGetComponent(out DoorX door))
            {
                baseHand.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.StateChange;
            }
            handModel.SetActive(false);
        }
    }

    public void EnableHandModel(SelectExitEventArgs arg)
    {
        if (arg.interactableObject.transform.GetComponent<InteractableInfo>().interactableType == InteractableInfo.InteractableType.HideHands)
        {
            if (handType == HandType.Left)
            {
                arg.interactableObject.transform.GetComponent<InteractableInfo>().GetLeftHand().SetActive(false);
            }
            else
            {
                arg.interactableObject.transform.GetComponent<InteractableInfo>().GetRightHand().SetActive(false);
            }
            interactor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.Sticky;
            if (arg.interactableObject.transform.TryGetComponent(out DoorX door))
            {
                baseHand.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.Sticky;
            }
            handModel.SetActive(true);  
        }
    }
}
