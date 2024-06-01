using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    SerializedDictionary<int, List<SpawnPointNode>> HordesManagement = new SerializedDictionary<int, List<SpawnPointNode>>();
    [SerializeField] float spawnInterval = 2.0f;
    [SerializeField] float spawnIntervalBetweenHordes = 2.0f;
    [SerializeField] EnemyAbstractClass enemyAbstractClass;

    EnemyAbstractClass enemyToSpawn;

    bool toSpawn;

    public void CreateEnemy(EnemiesEnum enemiesEnum)
    {
        Type enemyType = Type.GetType($"Assets.Scripts.EnemiesLogic.EnemyTypes.{enemiesEnum}");
        enemyToSpawn  = (EnemyAbstractClass) Activator.CreateInstance(enemyType);
        //To spawn bad AI
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < HordesManagement.Count; i++)
        {
            for (int j = 0; j < HordesManagement[i].Count; j++)
            {
                Instantiate(enemyAbstractClass
                    , transform.position
                    , Quaternion.identity);
                yield return new WaitForSeconds(spawnInterval);
            }
            yield return new WaitForSeconds(spawnIntervalBetweenHordes);
        }
    }

}

public enum EnemiesEnum
{
    Nevera,
    Microondas,
    Mordelon,
    PatiBomba
}