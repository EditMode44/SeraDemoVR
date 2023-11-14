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
    private bool startFan = true;

    private void Update()
    {
        if (startFan)
        {
            fanTurnPart.transform.DOBlendableLocalRotateBy(fanAxis, 2f);
            audioSource.Play();
        }
    }

    public void StartFan()
    {
        startFan = true;
        
    }


    public void StopFan()
    {
        startFan = false;
        audioSource.Stop();
    }
}
