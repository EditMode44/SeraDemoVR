using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DrillManager : MonoBehaviour
{
    [SerializeField] private LayerMask nutLayer;
    [SerializeField] private Transform sphereTransform;
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

            Collider[] nuts = Physics.OverlapSphere(sphereTransform.position, 0.0164766f, nutLayer);

            if (nuts.Length == 1)
            {
                if (nuts[0].transform.localPosition.y < nuts[0].GetComponent<Nut>().GetTargetY())
                {
                    nuts[0].transform.localPosition = Vector3.MoveTowards(nuts[0].transform.localPosition, new Vector3(0f, nuts[0].GetComponent<Nut>().GetTargetY(), 0f), 0.025f * Time.deltaTime);
                    nuts[0].transform.DOBlendableLocalRotateBy(new Vector3(0f, -rotateSpeed,  0f), rotateSmooth);
                }
            }
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
