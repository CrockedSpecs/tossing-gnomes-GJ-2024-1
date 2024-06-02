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

    [SerializeField] GameObject target;


    public int MaxLife { get => maxLife; set => maxLife = value; }
    public int Life { get => life; set => life = value; }
    public int BUMaxLife { get => bUMaxLife; set => bUMaxLife = value; }
    public int BULife { get => bULife; set => bULife = value; }
    public EnemiesEnum EnemyType { get => enemyType; set => enemyType = value; }
    public SpawnPoint SpawnPoint { get => spawnPoint; set => spawnPoint = value; }

    void Start()
    {
        target = spawnPoint.TargetToDestroy1;
        agent.SetDestination(new Vector2 
            (target
            .transform.position.x + 1
            , target
            .transform.position.y));
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
        if (gameObject.GetComponent<NavMeshAgent>()
                .enabled == true)
        {
            if (agent.remainingDistance <= 0.5f)
            {
                agent.isStopped = true;
                agent.enabled = false;
            }

        }
        
        if (target == null)
        {
            //Debug.Log();
            agent.enabled = true;
            target = spawnPoint.TargetToDestroy1;
            agent.SetDestination(new Vector2
                (
                target
                .transform.position.x + 1
                , target
                .transform.position.y
                ));
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Defensa"))
    //    {
    //        agent.isStopped = true;
    //    }
    //}
}
