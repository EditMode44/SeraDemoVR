using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlantingBasket : MonoBehaviour
{
    [SerializeField] private XRBaseInteractable interactable;
    [SerializeField] private MeshCollider meshCollider;
    [SerializeField] private Rigidbody rb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlantArea plantArea))
        {
            if (!plantArea.GetIsHavePlantBasket())
            {
                Cancel();
                rb.isKinematic = true;
                meshCollider.convex = false;
                interactable.enabled = false;
                transform.DOMove(plantArea.GetPlantTransform().position, 0.5f);
                transform.DORotateQuaternion(plantArea.GetPlantTransform().rotation, 0.5f);
                plantArea.SetPlantBasktet(this.gameObject);
            }
        }
    }


    public void Cancel()
    {
        ScrewSpawner.instance.GetXRInteractionManager().SelectExit(ScrewSpawner.instance.GetLeftInteractor(), (IXRSelectInteractable) interactable);
    }
}
