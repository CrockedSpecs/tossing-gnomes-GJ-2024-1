using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public Text waterText;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize waterText
        if (waterText == null)
        {
            Debug.LogError("waterText is not assigned in the Inspector");
            return;
        }

        // Set initial text
        waterText.text = "Water: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ResourceManager.Instance != null)
        {
            // Update the water text dynamically
            waterText.text = "Water: " + ResourceManager.Instance.WaterResources;
        }
        else
        {
            Debug.LogError("ResourceManager Instance is null");
        }
    }
}