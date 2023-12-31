using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantArea : MonoBehaviour
{
    [SerializeField] private Transform plantTransform;
    [SerializeField] private SeedCacher seedCacher;

    private GameObject plantBasktet;
    private bool isHavePlantBasktet;
    public Transform GetPlantTransform()
    {
        return plantTransform;
    }

    public void SetPlantBasktet(GameObject target)
    {
        plantBasktet = target;
    }

    public bool GetIsHavePlantBasket()
    { 
        if (plantBasktet != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public SeedCacher GetSeedCacher()
    {
        return seedCacher;
    }
    
}
