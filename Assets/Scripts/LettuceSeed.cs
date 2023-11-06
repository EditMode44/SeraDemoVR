using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LettuceSeed : MonoBehaviour
{
    [SerializeField] private XRBaseInteractable interactable;
    [SerializeField] private MeshCollider meshCollider;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip tickSound;

    private GameObject leftHandInteractable;
    private GameObject rightHandInteractable;

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
        if (other.gameObject.TryGetComponent(out PlantingBasket plantingBasket))
        {
            if (!plantingBasket.GetIsHaveSeed())
            {
                Cancel();
                plantingBasket.SetSeed(gameObject);
                rb.isKinematic = true;
                meshCollider.convex = false;
                interactable.enabled = false;
                transform.parent = plantingBasket.transform;
                transform.DOLocalMove(new Vector3(0f, 0.091f, 0f), 0.5f).OnComplete(() => audioSource.PlayOneShot(tickSound));
                transform.DOLocalRotate(Vector3.zero, 0.5f);
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
}
