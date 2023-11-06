using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] private float fanSpeed;
    [SerializeField] private Vector3 fanAxis;
    [SerializeField] private GameObject fanTurnPart;
    [SerializeField] private AudioSource audioSource;
    private bool startFan = false;

    private void Update()
    {
        if (startFan)
        {
            fanTurnPart.transform.DOBlendableLocalRotateBy(fanAxis, 2f);
        }
    }

    public void StartFan()
    {
        startFan = true;
        audioSource.Play();
    }


    public void StopFan()
    {
        startFan = false;
        audioSource.Stop();
    }
}
