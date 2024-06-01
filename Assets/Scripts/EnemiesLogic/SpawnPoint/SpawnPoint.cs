using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.Progress;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    LayerMask layer;

    [SerializeField]
    SerializedDictionary<int, List<SpawnPointNode>> HordesManagement = new SerializedDictionary<int, List<SpawnPointNode>>();
    [SerializeField] float spawnInterval = 2.0f;

    [SerializeField] float spawnIntervalBetweenHordes = 2.0f;

    [SerializeField] GameObject enemyAbstractClass;

    [SerializeField] GameObject TargetToDestroy;

    private void Awake()
    {

    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void FixedUpdate()
    {
        if (TargetToDestroy == null || !TargetToDestroy
            .activeInHierarchy)
        {
            Vector3 direction = 
                Vector3.zero - this.transform.position;
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, direction, out hit, direction.magnitude, layer))
            {
                // Si el rayo golpea un objeto en la capa especificada, guarda el GameObject en la variable
                TargetToDestroy = hit.collider.gameObject;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < HordesManagement.Count; i++)
        {
            foreach (var item in HordesManagement[i])
            {
                for(int j = 0; j < item.NumberOfEnemies; j++)
                {
                    enemyAbstractClass = Resources
                        .Load<GameObject>(item.enemiesEnum
                        .ToString());

                    /*Si el diccionario con objetos en uso
                    ya contiene el tipo entonces*/
                    Debug.Log(item.enemiesEnum.ToString());
                    if (EnemyObjectPooling
                        .sharedInstanceEnemyObjectPooling
                        .objectPoolingInUse
                        .ContainsKey
                        (item.enemiesEnum.ToString()))
                    {
                        /*Si hay elementos desactivados disponibles activara uno y lo pondra en el spawnpoint*/
                        if (EnemyObjectPooling
                        .sharedInstanceEnemyObjectPooling
                        .objectPooling[item.enemiesEnum
                        .ToString()].Count != 0)
                        {
                            //enemyAbstractClass =
                            //    EnemyObjectPooling
                            //.sharedInstanceEnemyObjectPooling
                            //.objectPooling[item.enemiesEnum
                            //.ToString()][0];
                            //

                            EnemyObjectPooling
                            .sharedInstanceEnemyObjectPooling
                            .objectPooling[item.enemiesEnum
                            .ToString()][0].SetActive(true);

                            EnemyObjectPooling
                            .sharedInstanceEnemyObjectPooling
                            .objectPooling[item.enemiesEnum
                            .ToString()][0].transform
                                .position =
                                new Vector3(
                                this.transform.position.x
                                , this.transform.position.y
                                , this.transform.position.z);
                        }
                        //si no hay elementos no activos disponibles entonces creara uno nuevo
                        else
                        {
                            enemyAbstractClass
                                .GetComponent
                                <EnemyAbstractClass>()
                                .EnemyType = item.enemiesEnum;
                            EnemyObjectPooling
                            .sharedInstanceEnemyObjectPooling
                            .objectPoolingInUse[item.enemiesEnum
                            .ToString()].Add(
                            Instantiate
                                (enemyAbstractClass
                                , transform.position
                                , Quaternion.identity)
                            );
                        }
                    }
                    /*Si el diccionario con objetos en uso
                    no contiene el tipo entonces creara un 
                    nuevo elemento en el diccionario con el 
                    tipo y una nueva lista, tanto el 
                    diccionario en uso como en el disponible 
                    */
                    else
                    {
                        //añade primero el tipo al enemigo
                        enemyAbstractClass
                                .GetComponent
                                <EnemyAbstractClass>()
                                .EnemyType = item.enemiesEnum;
                        EnemyObjectPooling
                        .sharedInstanceEnemyObjectPooling
                        .objectPooling.Add
                        (item.enemiesEnum.ToString()
                        , new List<GameObject>());

                        EnemyObjectPooling
                        .sharedInstanceEnemyObjectPooling
                        .objectPoolingInUse.Add
                        (
                            item.enemiesEnum.ToString()
                            , new List<GameObject>
                            {
                                Instantiate
                                    (enemyAbstractClass
                                    , transform.position
                                    , Quaternion.identity)
                            }
                        );
                    }

                    yield return new 
                        WaitForSeconds(spawnInterval);
                }
                yield return new
                    WaitForSeconds(spawnInterval);
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