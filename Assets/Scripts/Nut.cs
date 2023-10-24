using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    [SerializeField] private float nutTargetY;

    public float GetTargetY()
    {
        return nutTargetY;
    }
}
