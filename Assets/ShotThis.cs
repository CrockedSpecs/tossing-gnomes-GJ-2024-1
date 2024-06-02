using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotThis : MonoBehaviour
{
    public GameObject MovingPart;
    public GameObject Projectile;

    public List<GameObject> Enemies = new List<GameObject>();

    public Transform FirePoint; // Where the projectile will be instantiated from
    public float FireRate = 1f; // Time between shots
    private float nextFireTime = 0f;

    private void Update()
    {
        checkForEnemies();
        if (Time.time >= nextFireTime)
        {
            shot(Projectile);
            nextFireTime = Time.time + 1f / FireRate;
        }
    }

    public void checkForEnemies()
    {
        if (Enemies.Count > 0)
        {
            Vector3 direction = Enemies[0].transform.position - MovingPart.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            MovingPart.transform.rotation = Quaternion.Slerp(MovingPart.transform.rotation, rotation, Time.deltaTime * 5f); // Smooth rotation
        }
    }

    public void shot(GameObject projectile)
    {
        if (Enemies.Count > 0)
        {
            GameObject Bullet = Instantiate(projectile, FirePoint.position, FirePoint.rotation);
            Bullet.AddComponent<ProyectileBehavior>();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemies.Remove(other.gameObject);
        }
    }
}


