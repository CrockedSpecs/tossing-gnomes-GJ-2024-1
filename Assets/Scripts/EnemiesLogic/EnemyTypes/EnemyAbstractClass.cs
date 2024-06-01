using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbstractClass : MonoBehaviour
{
    [SerializeField] int MaxLife;
    [SerializeField] int Life;

    [SerializeField] float speed = 1.0f; // Velocidad de movimiento

    private float startTime;
    private float journeyLength;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(this.transform.position, Vector3.zero);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(this.transform.position, Vector3.zero, fractionOfJourney);
    }

}
