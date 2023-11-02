using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CollectTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip panelClip;
    [SerializeField] private AudioClip collectStartClip;
    [SerializeField] private AudioClip collectEndClip;


    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out LocomotionSystem loc))
        {
            if (!triggered)
            {
                audioSource.PlayOneShot(panelClip);
                triggered = true;
            }
        }
    }
}
