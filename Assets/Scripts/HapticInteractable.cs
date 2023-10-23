using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticInteractable : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float intensity;
    [SerializeField] protected float duration;

    private bool triggered;
    private XRBaseControllerInteractor controllerInteractor;

    private void Update()
    {
        if (triggered)
        {
            TriggerHaptic(controllerInteractor.xrController);
        }
    }

    public void TriggerHaptic(BaseInteractionEventArgs eventArgs)
    {
        
        if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            triggered = true;
            this.controllerInteractor = controllerInteractor;
        }
    }

    public void CancelHaptic(BaseInteractionEventArgs eventArgs)
    {
        if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            triggered = false;
            this.controllerInteractor = controllerInteractor;
        }
    }

    public void TriggerHaptic(XRBaseController controller)
    {
        if (intensity > 0)
        {
            controller.SendHapticImpulse(intensity, duration);
        }
    }
}
