using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour
{
    [SerializeField] private GameObject nut;
    [SerializeField] private Vector3 nutTargetTransform;
    private bool isRight;
    private Rigidbody rb;
    private MeshCollider meshCollider;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        meshCollider = GetComponent<MeshCollider>();
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
                meshCollider.enabled = false;

                screwArea.SetScrew(this.gameObject);
                transform.SetParent(screwArea.transform.parent);
                transform.DOLocalMove(Vector3.zero - new Vector3(0f, screwArea.GetYOffset(), 0f), 0.25f).OnComplete(() => nut.SetActive(true));
                transform.DOLocalRotate(Vector3.zero, 0.25f);

                //-0.0772
            }
        }
    }
}
