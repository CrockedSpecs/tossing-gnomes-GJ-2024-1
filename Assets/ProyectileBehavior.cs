using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProyectileBehavior : MonoBehaviour
{
    public int proyectileSpeed;

    void Update()
    {
        // Move the projectile forward every frame
        transform.position += transform.forward * proyectileSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the projectile when it hits an enemy
            Destroy(gameObject);

            // Optionally, you can destroy the enemy or apply damage here
            // Destroy(collision.gameObject);
        }
    }
}
