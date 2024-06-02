using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckResorces : MonoBehaviour
{

    public GameObject Resources;
    public int EnergyCost;
    public int MetalCost;
   public void OnButtonDown()
    {
        checkResources();
    }

    private void checkResources()
    {
        if ( Resources.GetComponent<ResourceStorage>().Energy > EnergyCost && Resources.GetComponent<ResourceStorage>().Metal > MetalCost)
        {

        }
    }
}
