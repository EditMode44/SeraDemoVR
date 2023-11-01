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
    [SerializeField] private Transform[] largeHandTransforms; 
    [SerializeField] private Transform[] smallHandTransforms;
    [SerializeField] private GameObject largePoseParent;
    [SerializeField] private GameObject smallPoseParent;
    private GameObject currentParent;
    public bool completed;


    private void Start()
    {
        if (isLarge)
        {
            handTransforms = largeHandTransforms;
            currentParent = largePoseParent;
        }
        else
        {
            handTransforms = smallHandTransforms;
            currentParent = smallPoseParent;
        }
    }

    
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

    public GameObject GetCurrentParent()
    {
        return currentParent;
    }


}
