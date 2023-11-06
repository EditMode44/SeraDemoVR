using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlantTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip plantClip;
    [SerializeField] private AudioClip plantCompleteClip;

    [SerializeField] private SeedCacher[] seedCacher;
    [SerializeField] private GameObject triggerArea;
    [SerializeField] private GameObject collectTrigger;

    private bool triggered;

    private bool next;


    private void Update()
    {
        if (seedCacher[0].GetIsHaveSeed() && seedCacher[1].GetIsHaveSeed() && seedCacher[2].GetIsHaveSeed() && seedCacher[3].GetIsHaveSeed())
        {
            if(!next)
            {
                audioSource.PlayOneShot(plantCompleteClip);
                triggerArea.SetActive(false);
                collectTrigger.SetActive(true);
                next = true;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out LocomotionSystem loc))
        {
            if (!triggered)
            {
                audioSource.PlayOneShot(plantClip);
                triggered = true;
            }
        }
    }

}
