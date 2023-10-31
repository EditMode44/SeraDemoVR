using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildPartData", menuName = "BuildPart/BuildPartData")]
public class BuildPartData : ScriptableObject
{
    public Vector3 defaultPosition;
    public Vector3 defaultRotation;

    public AudioClip sound;
    public Ease easeType;
    public float smoothTime;

    public bool isMountable;

    public Vector3 playerPosition;
    public Vector3 playerRotation;

    public float waitTime;

}
