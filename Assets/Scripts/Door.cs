using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject tutorialItemsParent;
    [SerializeField] private GameObject door;
    [SerializeField] private Collider triggerCollider;
    [SerializeField] private Collider normalCollider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out LocomotionSystem loc))
        {
            tutorialItemsParent.SetActive(false);
            triggerCollider.enabled = false;
            normalCollider.enabled = true;
            door.transform.localEulerAngles = Vector3.zero;
        }
    }
}
