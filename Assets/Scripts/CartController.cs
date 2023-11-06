using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CartController : MonoBehaviour
{
    [SerializeField] private float wheelSpeedMultiplier;
    [SerializeField] private ContinuousMoveProviderBase continuousMoveProvider;
    [SerializeField] private float targetSpeed;
    [SerializeField] private GameObject vagonMeshCol;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Rigidbody vagonMeshRb;
    [SerializeField] private GameObject[] wheels;
    private float defaultPlayerMoveSpeed;


    private void Start()
    {
        defaultPlayerMoveSpeed = continuousMoveProvider.moveSpeed;
    }

    private void Update()
    {
        vagonMeshRb.MovePosition(this.transform.position);

        if (rb.velocity.magnitude > 0f)
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].transform.DOBlendableLocalRotateBy(new Vector3(0f, 0f, rb.velocity.z * wheelSpeedMultiplier), 0.1f);
            }
        }
    }

    public void HoverEntered()
    {
        continuousMoveProvider.moveSpeed = targetSpeed;
        rb.isKinematic = false;
    }

    public void HoverExited()
    {
        continuousMoveProvider.moveSpeed = defaultPlayerMoveSpeed;
        rb.isKinematic = false;
    }
}
