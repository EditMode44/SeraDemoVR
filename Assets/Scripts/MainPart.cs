using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPart : MonoBehaviour
{
    public static MainPart instance;
    [SerializeField] private Vector3[] positions;
    [SerializeField] private Vector3[] eulers;
    [SerializeField] private ScrewArea[] screwAreas;
    [SerializeField] private Pipe[] pipes;
    [SerializeField] private BuildPart buildPart;
    private int currentPosIndex = -1;
    private int currentAreaIndex;

    private bool goPos;

    private bool mount;
    private void Awake()
    {
        instance = this;
        buildPart.GetBuildPartData().isMountable = true;
    }

    private void Start()
    {
        mount = true;
        
    }

    private void Update()
    {
        if (screwAreas[currentAreaIndex].GetCompleted())
        {
            if (screwAreas[currentAreaIndex] != screwAreas[screwAreas.Length - 1]) 
            {
                goPos = true;
                currentPosIndex++;
                currentAreaIndex++;
            }
            else
            {
                if (buildPart.GetBuildPartData().isMountable)
                {
                    foreach (ScrewArea item in screwAreas)
                    {
                        item.gameObject.SetActive(false);
                    }
                    buildPart.GetBuildPartData().isMountable = false;
                    buildPart.GoTargetPos();
                }
            }
        }


        if (currentAreaIndex > -1 && goPos)
        {
            mount = false;
            transform.DOLocalMove(positions[currentPosIndex], 1f);
            transform.DOLocalRotate(eulers[currentPosIndex], 1f);
            if (pipes[currentAreaIndex] != null)
            {
                transform.DOLocalMove(positions[currentPosIndex], 1f).OnComplete(() => pipes[currentAreaIndex].gameObject.SetActive(true));
                transform.DOLocalRotate(eulers[currentPosIndex], 1f);
                pipes[currentAreaIndex].transform.DOLocalMove(pipes[currentAreaIndex].GetBuildData().defaultPosition, 1f).SetDelay(0.75f).OnComplete(()=> mount = true);
                pipes[currentAreaIndex].transform.DOLocalRotate(pipes[currentAreaIndex].GetBuildData().defaultRotation, 1f).SetDelay(0.75f);
            }
            else
            {
                transform.DOLocalMove(positions[currentPosIndex], 1f).OnComplete(() => mount = true);
                transform.DOLocalRotate(eulers[currentPosIndex], 1f);
            }
            goPos = false;
        }
    }


    public ScrewArea GetCurrentScrewArea()
    {
        return screwAreas[currentAreaIndex];
    }

    public bool GetMount()
    {
        return mount;
    }
}
