using DG.Tweening;
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

    [SerializeField] private GameObject[] lettuces;
    [SerializeField] private GameObject[] lettuceSeeds;

    private bool triggered;

    private bool growPlants = true;
    [SerializeField] private int correctCelciousValue = 28;
    [SerializeField] private string correctPhValue = "7.1";
    [SerializeField] private int correctMinValue = 12;
    [SerializeField] private ControlPanel controlPanel;

    private bool playLastAudio;

    private void Update()
    {
        if (controlPanel.GetCelciousValue() == correctCelciousValue && (controlPanel.GetPhValue() > 7.05f && controlPanel.GetPhValue() < 7.15f) && controlPanel.GetMinValue() == correctMinValue && growPlants)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(collectStartClip);
            GrowPlants();

            if (!playLastAudio)
            {
                Invoke(nameof(PlayLastAudio), 10);
                playLastAudio = true;
            }

            growPlants = false;
        }
    }


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



    private void GrowPlants()
    {
        foreach (GameObject go in lettuces)
        {
            go.transform.DOScale(1f, 2f);
        }


        foreach (GameObject item in lettuceSeeds)
        {
            item.transform.DOScale(0f, 2f);
        }
    }

    private void PlayLastAudio()
    {
        audioSource.PlayOneShot(collectEndClip);
    }
}
