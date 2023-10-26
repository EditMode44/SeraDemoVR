using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    [SerializeField] private AudioClip[] footStepSounds;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private AudioSource audioSource;



    private void Update()
    {
        if (characterController.velocity.magnitude > 1f)
        {
            if (!audioSource.isPlaying)
            {
                int randomIndex = Random.Range(0, footStepSounds.Length);
                audioSource.PlayOneShot(footStepSounds[randomIndex]);
            }
        }
    }


}
