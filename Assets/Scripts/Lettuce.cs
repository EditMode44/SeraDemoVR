using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Lettuce : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    public void MakeKinematicFalse(SelectExitEventArgs args)
    {
        rb.isKinematic = false;
    }
}
