using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResources : MonoBehaviour
{
    public TMP_InputField Energy;
    public TMP_InputField Metal;
    
    void Update()
    {
        Energy.text = GetComponent<ResourceStorage>().Energy.ToString();

        Metal.text = GetComponent<ResourceStorage>().Metal.ToString();
    }
}
