using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorX : MonoBehaviour
{
    public void OnSelect(SelectEnterEventArgs arg)
    {
        transform.DOMoveX(-25f, 1f);
    }
}
