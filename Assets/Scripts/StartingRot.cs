using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;

public class StartingRot : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    private bool fix;

    private void Update()
    {
        if (!fix && XRSettings.enabled && cameraTransform.localEulerAngles.y > 1f)
        {
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y - cameraTransform.localEulerAngles.y, 0f);
            fix = true; 
        }
    }
}
