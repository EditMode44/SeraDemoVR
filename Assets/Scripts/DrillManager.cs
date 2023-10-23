using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DrillManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip drillStart;
    [SerializeField] private AudioClip drillLoop;
    [SerializeField] private AudioClip drillEnd;
    [SerializeField] private Transform turningPart;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float rotateSmooth;

    private bool activated;

    private void Update()
    {
        if (activated)
        {
            turningPart.transform.DOBlendableLocalRotateBy(new Vector3(0f, 0f, rotateSpeed), rotateSmooth);
        }
    }

    public void Activated()
    {
        activated = true;
        audioSource.clip = drillLoop;
        audioSource.loop = true;
        audioSource.Play();
        
    }


    public void DeActivated()
    {
        activated = false;
        audioSource.clip = null;
        audioSource.loop = false;
        audioSource.PlayOneShot(drillEnd);
    }
}
