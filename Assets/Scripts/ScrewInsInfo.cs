using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewInsInfo : MonoBehaviour
{
    private bool instantiateable;



    public bool GetInstantiateable()
    {
        return instantiateable;
    }

    public void SetInstantiateable(bool state)
    {
        instantiateable = state;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ScrewTrigger")) 
        {
            instantiateable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        instantiateable = false;
    }
}
