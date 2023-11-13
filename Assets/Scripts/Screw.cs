using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour
{
    [SerializeField] private GameObject nut;
    [SerializeField] private Vector3 nutTargetTransform;
    [SerializeField] private bool canBeRepositioned;
    private bool isRight;
    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;


    private Vector3 startPosition;
    private Quaternion startRotation;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void SetIsRight(bool state)
    {
        isRight = state;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ScrewArea screwArea))
        {
            if (!screwArea.IsHaveScrew() && screwArea == MainPart.instance.GetCurrentScrewArea() && MainPart.instance.GetMount())
            {
                nut.GetComponent<Nut>().SetScrewArea(screwArea);
                if (isRight)
                {
                    ScrewSpawner.instance.CancelRight();
                }
                else
                {
                    ScrewSpawner.instance.CancelLeft();
                }

                Destroy(GetComponent<XRGrabInteractableTwoAttach>());
                Destroy(rb);
                capsuleCollider.enabled = false;

                screwArea.SetScrew(this.gameObject);
                transform.SetParent(screwArea.transform.parent);
                transform.DOLocalMove(Vector3.zero - new Vector3(0f, screwArea.GetYOffset(), 0f), 0.25f).OnComplete(() => nut.SetActive(true));
                transform.DOLocalRotate(Vector3.zero, 0.25f);

                //-0.0772
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canBeRepositioned)
        {
            if (transform.position.y < 0.5979f && !rb.isKinematic)
            {
                transform.position = startPosition;
                transform.rotation = startRotation;
            }
        }
    }
}
