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

    [SerializeField] int shootRate;

    [SerializeField] SpawnPoint spawnPoint;

    //[SerializeField] float speed = 1.0f; // Velocidad de movimiento

    [SerializeField] NavMeshAgent agent;

    [SerializeField] GameObject target;

    public float speed = 1.0f; // Velocidad de movimiento
    private float startTime;
    private float journeyLength;
    private bool initiate = false;

    public int MaxLife { get => maxLife; set => maxLife = value; }
    public int Life { get => life; set => life = value; }
    public int BUMaxLife { get => bUMaxLife; set => bUMaxLife = value; }
    public int BULife { get => bULife; set => bULife = value; }
    public EnemiesEnum EnemyType { get => enemyType; set => enemyType = value; }
    public SpawnPoint SpawnPoint { get => spawnPoint; set => spawnPoint = value; }

    void Start()
    {
        //target = spawnPoint.TargetToDestroy1;
        //agent.SetDestination(new Vector2 
        //    (target
        //    .transform.position.x 
        //    , target
        //    .transform.position.y));
        StartCoroutine(WaitAndPrint());
        BUMaxLife = MaxLife;
        BULife = Life;
    }

    private void OnEnable()
    {
        MaxLife = BUMaxLife;
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

    void FixedUpdate()
    {
        // Calcula la fracción del viaje completada
        if (spawnPoint.TargetToDestroy1 != null)
        {
            if (initiate)
            { 
                //spawnPoint.TargetToDestroy1.transform.position)
                target = spawnPoint.TargetToDestroy1;

                float distCovered = (Time.time - startTime) * speed;
                float fractionOfJourney = distCovered / journeyLength;

                // Mueve el GameObject de punto A a punto B
                transform.position = Vector3.Lerp
                    (this.transform
                    .position
                    , new Vector2(spawnPoint.TargetToDestroy1
                    .transform.position.x + 0.5f
                    , spawnPoint.TargetToDestroy1
                    .transform.position.y)
                    , fractionOfJourney);
            }
        }
    }

    IEnumerator WaitAndPrint()
    {
        // Espera 5 segundos
        yield return new WaitForSeconds(2);

        startTime = Time.time;
        journeyLength = Vector3.Distance
            (this.transform.position
            , spawnPoint.TargetToDestroy1
            .transform.position)
            * 0.5f;
        initiate = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Defensa"))
        {
            StartCoroutine(ShootBullet(collision));
        }
    }

    IEnumerator ShootBullet(Collider2D collision)
    {
        yield return new WaitForSeconds(shootRate);
            collision.transform.gameObject
            .GetComponent<RangeOfDamage>().Father
            .GetComponent<turretBehaviour>().life--;
    }
    
    
    
    
}
