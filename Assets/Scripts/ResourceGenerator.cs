using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    public ResourceManager resourceManager;
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
        //en un inicio genera la mitad de los recursos instnaciados en el inspector tras el initialTime
        if (justCreated)
        {
            yield return new WaitForSeconds(initialTime);
            Collect(Mathf.CeilToInt(waterGenerated / 2f));
            justCreated = false;
        }
        //luego, cada timeInterval se generan los recursos completos
        while (true && !justCreated)
        {
            yield return new WaitForSeconds(timeInterval);
            Collect(waterGenerated);
        }
    }

    void Collect(int amount)
    {
        resourceManager.WaterResources += amount;
    }
}