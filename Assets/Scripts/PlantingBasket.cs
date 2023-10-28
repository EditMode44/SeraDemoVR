using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlantingBasket : MonoBehaviour
{
    [SerializeField] private XRBaseInteractable interactable;
    [SerializeField] private MeshCollider meshCollider;
    [SerializeField] private Rigidbody rb;

    private GameObject leftHandInteractable;
    private GameObject rightHandInteractable;
    private void Start()
    {
        ScrewSpawner.instance.GetLeftInteractor().selectEntered.AddListener(FindLeftHandInteractable);
        ScrewSpawner.instance.GetRightInteractor().selectEntered.AddListener(FindRightHandInteractable);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlantArea plantArea))
        {
            if (!plantArea.GetIsHavePlantBasket())
            {
                plantArea.SetPlantBasktet(this.gameObject);
                Cancel();
                rb.isKinematic = true;
                meshCollider.convex = false;
                interactable.enabled = false;
                transform.DOMove(plantArea.GetPlantTransform().position, 0.5f);
                transform.DORotateQuaternion(plantArea.GetPlantTransform().rotation, 0.5f);
                
            }
        }
    }


    public void Cancel()
    {
        if (leftHandInteractable != null && leftHandInteractable == this.gameObject)
        {
            ScrewSpawner.instance.GetXRInteractionManager().SelectExit(ScrewSpawner.instance.GetLeftInteractor(), (IXRSelectInteractable)interactable);
            return;
        }

        if (rightHandInteractable != null && rightHandInteractable == this.gameObject)
        {
            ScrewSpawner.instance.GetXRInteractionManager().SelectExit(ScrewSpawner.instance.GetRightInteractor(), (IXRSelectInteractable)interactable);
        }
    }

    private void FindRightHandInteractable(SelectEnterEventArgs args)
    {
        rightHandInteractable = args.interactableObject.transform.gameObject;
    }

    private void FindLeftHandInteractable(SelectEnterEventArgs args)
    {
        leftHandInteractable = args.interactableObject.transform.gameObject;
    }
}
