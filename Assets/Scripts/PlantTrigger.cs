using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlantTrigger : MonoBehaviour
{
    public static PlantTrigger instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip plantClip;
    [SerializeField] private AudioClip plantCompleteClip;

    
    [SerializeField] private GameObject triggerArea;
    [SerializeField] private GameObject collectTrigger;
    [SerializeField] private Transform collectTransform;

    private List<PlantingBasket> plantingBaskets = new List<PlantingBasket>();  

    private bool triggered;

    private bool next;

    [SerializeField] private XRDirectInteractor interactor;
    [SerializeField] private XRDirectInteractor baseHand;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (plantingBaskets.Count == 4)
        {
            if (plantingBaskets[0].GetIsHaveSeed() && plantingBaskets[1].GetIsHaveSeed() && plantingBaskets[2].GetIsHaveSeed() && plantingBaskets[3].GetIsHaveSeed())
            {
                if (!next)
                {
                    audioSource.PlayOneShot(plantCompleteClip);
                    triggerArea.SetActive(false);
                    collectTrigger.SetActive(true);
                    interactor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.StateChange;
                    baseHand.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.StateChange;
                    Invoke(nameof(Teleport), 2.5f);
                    next = true;
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out LocomotionSystem loc))
        {
            if (!triggered)
            {
                Invoke(nameof(PlayAudio), 1.5f);
                triggered = true;
            }
        }
    }

    public List<PlantingBasket> GetPlantingBaskets()
    {
        return plantingBaskets;
    }

    private void Teleport()
    {
        TeleportManager.instance.Teleport(collectTransform);
    }

    public void PlayAudio()
    {
        audioSource.PlayOneShot(plantClip);
    }
}
