using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableInfo : MonoBehaviour
{
    public GameObject handModel;
    public GameObject leftHandModel;
    public enum InteractableType
    {
        HideHands,
        NonHideHands
    }

    public InteractableType interactableType;

    public GameObject GetRightHand()
    {
        return handModel;
    }

    public GameObject GetLeftHand()
    {
        return leftHandModel;    
    }
}
