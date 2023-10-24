using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewArea : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float yOffset = 0.0377f;
    private GameObject screw;


    public Transform GetTargetTransform()
    {
        return targetTransform;
    }

    public float GetYOffset()
    {
        return yOffset;
    }

    public void SetScrew(GameObject screw)
    {
        this.screw = screw;
    }

    public bool IsHaveScrew()
    {
        return screw != null;
    }
}
