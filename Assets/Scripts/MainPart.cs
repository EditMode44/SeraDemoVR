using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPart : MonoBehaviour
{
    [SerializeField] private Vector3[] positions;
    [SerializeField] private Vector3[] eulers;
    [SerializeField] private ScrewArea[] screwAreas;

    private int currentPosIndex = -1;
    private int currentAreaIndex;

    private bool goPos;

    private void Start()
    {
        Array.Reverse(screwAreas);
    }


    private void Update()
    {
        if (screwAreas[currentAreaIndex].GetCompleted())
        {
            goPos = true;
            currentPosIndex++;
            currentAreaIndex++;
        }


        if (currentAreaIndex > -1 && goPos)
        {
            transform.DOLocalMove(positions[currentPosIndex], 1f);
            transform.DOLocalRotate(eulers[currentPosIndex], 1f);
            goPos = false;
        }
    }


    public ScrewArea GetCurrentScrewArea()
    {
        return screwAreas[currentAreaIndex];
    }
}
