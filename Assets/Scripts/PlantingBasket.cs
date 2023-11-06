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
    [SerializeField] private CapsuleCollider capsuleCollider;

    private GameObject leftHandInteractable;
    private GameObject rightHandInteractable;
    private GameObject seed;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private void Start()
    {
        ScrewSpawner.instance.GetLeftInteractor().selectEntered.AddListener(FindLeftHandInteractable);
        ScrewSpawner.instance.GetRightInteractor().selectEntered.AddListener(FindRightHandInteractable);
        startPosition = transform.position;
        startRotation = transform.rotation;
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
                meshCollider.enabled = false;
                interactable.enabled = false;
                capsuleCollider.enabled = true;
                capsuleCollider.isTrigger = true;
                transform.DOMove(plantArea.GetPlantTransform().position - new Vector3(0f, 0.063f, 0f), 0.5f);
                transform.DORotateQuaternion(plantArea.GetPlantTransform().rotation, 0.5f);
                
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.position.y <= 0.4f && !rb.isKinematic)
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
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

    public void SetSeed(GameObject seed)
    {
        this.seed = seed;
    }

    public bool GetIsHaveSeed()
    {
        return seed != null;
    }
}
