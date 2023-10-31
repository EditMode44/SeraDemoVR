using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private BuildPartData buildData;

    public BuildPartData GetBuildData()
    {
        return buildData;
    }
}
