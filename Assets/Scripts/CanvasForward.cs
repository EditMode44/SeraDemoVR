using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasForward : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    private void Update()
    {
        transform.forward = playerCamera.forward;
    }
}
