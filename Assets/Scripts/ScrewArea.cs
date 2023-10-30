using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewArea : MonoBehaviour
{
    [SerializeField] private bool isLarge;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float yOffset = 0.0377f;

    [SerializeField] private Transform[] handTransforms;
    private GameObject screw;

    private bool completed;
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

    public Transform[] GetHandTransforms()
    {
        return handTransforms;
    }

    public bool GetIsLarge()
    {
        return isLarge;
    }

    public bool GetCompleted()
    {
        return completed;
    }

    public void SetCompleted(bool state)
    {
        completed = state;
    }
}
