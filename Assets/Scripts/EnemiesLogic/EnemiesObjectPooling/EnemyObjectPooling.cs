using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPooling : MonoBehaviour
{
    public SerializedDictionary<string, List<GameObject>> objectPooling;
    public SerializedDictionary<string, List<GameObject>> objectPoolingInUse;
    public static EnemyObjectPooling sharedInstanceEnemyObjectPooling;
    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        if (sharedInstanceEnemyObjectPooling == null)
        {
            sharedInstanceEnemyObjectPooling = this;
        }
    }

}
