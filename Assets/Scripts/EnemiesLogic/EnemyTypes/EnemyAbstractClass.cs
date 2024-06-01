using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAbstractClass : MonoBehaviour
{
    [SerializeField] EnemiesEnum enemyType;
    [SerializeField] int maxLife;
    [SerializeField] int life;

    [SerializeField] int bUMaxLife;
    [SerializeField] int bULife;

    [SerializeField] SpawnPoint spawnPoint;

    //[SerializeField] float speed = 1.0f; // Velocidad de movimiento

    [SerializeField] NavMeshAgent agent;


    public int MaxLife { get => maxLife; set => maxLife = value; }
    public int Life { get => life; set => life = value; }
    public int BUMaxLife { get => bUMaxLife; set => bUMaxLife = value; }
    public int BULife { get => bULife; set => bULife = value; }
    public EnemiesEnum EnemyType { get => enemyType; set => enemyType = value; }
    public SpawnPoint SpawnPoint { get => spawnPoint; set => spawnPoint = value; }

    void Start()
    {
        agent.SetDestination((Vector2)spawnPoint
            .TargetToDestroy1.transform.position);
        BUMaxLife = MaxLife;
        BULife = Life;
    }
    private void OnEnable()
    {
        MaxLife =BUMaxLife;
        Life = BULife;
    }
    private void OnDisable()
    {
        EnemyObjectPooling
        .sharedInstanceEnemyObjectPooling
        .objectPoolingInUse[enemyType.ToString()]
        .Remove(this.gameObject);

        EnemyObjectPooling
        .sharedInstanceEnemyObjectPooling
        .objectPooling[enemyType.ToString()]
        .Add(this.gameObject);

    }

    void Update()
    {
        if (!agent.hasPath)
        {
            if ((Vector2)agent.transform.position != (Vector2)spawnPoint
                .TargetToDestroy1.transform.position)
            {
                agent.SetDestination((Vector2)spawnPoint
                .TargetToDestroy1.transform.position);
            }
            if (Life <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    
}
