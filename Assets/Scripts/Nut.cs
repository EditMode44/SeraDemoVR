using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    [SerializeField] private float nutTargetY;
    [SerializeField] private ScrewArea screwArea;

    public float GetTargetY()
    {
        return nutTargetY;
    }

    public ScrewArea GetScrewArea()
    {
        return screwArea;
    }

    public void SetScrewArea(ScrewArea target)
    {
        screwArea = target;
    }
}
