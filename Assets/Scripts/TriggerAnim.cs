using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerAnim : MonoBehaviour
{
    private bool triggered;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out LocomotionSystem loc))
        {
            if (!triggered) 
            {
                BuildingManager.instance.StartAnim();
                triggered = true;
            }
        }
    }
}
