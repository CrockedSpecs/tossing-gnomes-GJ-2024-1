using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    public int waterGenerated;
    public float timeInterval;
    public float initialTime;
    private bool justCreated;

    // Start is called before the first frame update
    void Start()
    {
        justCreated = true;
        StartCoroutine(CollectResource());
    }

    IEnumerator CollectResource()
    {
        // Initially generate half of the resources specified in the inspector after the initialTime
        if (justCreated)
        {
            yield return new WaitForSeconds(initialTime);
            Collect(Mathf.CeilToInt(waterGenerated / 2f));
            justCreated = false;
        }
        // Then, generate the full amount of resources every timeInterval
        while (!justCreated)
        {
            yield return new WaitForSeconds(timeInterval);
            Collect(waterGenerated);
        }
    }

    void Collect(int amount)
    {
        ResourceManager.Instance.WaterResources += amount;
        Debug.Log(ResourceManager.Instance.WaterResources);
    }
}