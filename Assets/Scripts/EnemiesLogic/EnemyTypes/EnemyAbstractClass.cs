using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbstractClass : MonoBehaviour
{
    [SerializeField] EnemiesEnum enemyType;
    [SerializeField] int maxLife;
    [SerializeField] int life;

    [SerializeField] int bUMaxLife;
    [SerializeField] int bULife;

    [SerializeField] float speed = 1.0f; // Velocidad de movimiento

    private float startTime;
    private float journeyLength;

    public int MaxLife { get => maxLife; set => maxLife = value; }
    public int Life { get => life; set => life = value; }
    public int BUMaxLife { get => bUMaxLife; set => bUMaxLife = value; }
    public int BULife { get => bULife; set => bULife = value; }
    public EnemiesEnum EnemyType { get => enemyType; set => enemyType = value; }

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(this.transform.position, Vector3.zero);
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
        if (true)
        {
            
        }
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3
            .Lerp(this.transform.position
            , Vector3.zero, fractionOfJourney);

        if (Life <= 0)
        {
            this.gameObject.SetActive(false);   
        }
    }

}
