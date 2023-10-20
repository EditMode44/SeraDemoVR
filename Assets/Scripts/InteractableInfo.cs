using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableInfo : MonoBehaviour
{
    public GameObject handModel;
    public enum InteractableType
    {
        HideHands,
        NonHideHands
    }

    public InteractableType interactableType;
}
