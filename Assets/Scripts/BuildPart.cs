using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPart : MonoBehaviour
{
    [SerializeField] private BuildPartData buildPartData;
    [SerializeField] private GameObject particle;
    [SerializeField] private bool mountComplete;

    public void GoTargetPos()
    {
        if (!buildPartData.isMountable) 
        {
            transform.DOLocalMove(buildPartData.defaultPosition, buildPartData.smoothTime).SetEase(buildPartData.easeType).OnComplete(() => particle.SetActive(true));
            transform.DOLocalRotate(buildPartData.defaultRotation, buildPartData.smoothTime).SetEase(buildPartData.easeType).OnComplete(() =>
            BuildingManager.instance.PlaySound(buildPartData.sound)
            );
        }
        else
        {
            transform.DOLocalMove(buildPartData.playerPosition, buildPartData.smoothTime).SetEase(buildPartData.easeType);
            transform.DOLocalRotate(buildPartData.playerRotation, buildPartData.smoothTime).SetEase(buildPartData.easeType);
        }
    }


    public BuildPartData GetBuildPartData()
    {
        return buildPartData;
    }


    public bool GetMountComplete()
    {
        return mountComplete;
    }

    public void SetMountComplete(bool mountComplete)
    {
        this.mountComplete = mountComplete;
    }
}
