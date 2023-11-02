using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SeedCacher : MonoBehaviour
{
    public bool isHaveSeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out LettuceSeed lettuce))
        {
            if (!lettuce.GetComponent<Rigidbody>().isKinematic) 
            {
                isHaveSeed = true;
                lettuce.GetComponent<XRGrabInteractable>().enabled = false;
            }
        }
    }


    public bool GetIsHaveSeed()
    {
        return isHaveSeed;
    }
}
