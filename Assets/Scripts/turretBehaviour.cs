using System.Collections;
using UnityEngine;

public class turretBehaviour : MonoBehaviour
{
    [Header("Turret Stats")]
    public float life;
    public float maintenanceCost;
    public bool isDamaged;

    [Header("Shooting Settings")]
    public float shootRate;
    public float shootRange;
    public float shootSpeed;
    public float bulletDamage;
    public GameObject bullet;

    public bool isShooting;
    public int enemyAtRange;

    public Transform parentTransform;


    void Start()
    {
        enemyAtRange = 0;
        isShooting = false;
        isDamaged = false;
        //StartCoroutine(ShootBullet());
    }


    void Update()
    {
        if (enemyAtRange == 0)
        {
            isShooting = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy")) 
        {
            enemyAtRange++;
            if (!isShooting){
                if (enemyAtRange == 1)
                {
                    isShooting = true;
                    StartCoroutine(ShootBullet());
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyAtRange -= 1;
        }
    }

        IEnumerator ShootBullet()
    {
        while (isShooting)
        {
            yield return new WaitForSeconds(shootRate);
 
                if (!isDamaged)
                {
                    GameObject newBullet = Instantiate(bullet, parentTransform.position, parentTransform.rotation, parentTransform);
                    bulletBehaviour bulletScript = newBullet.GetComponent<bulletBehaviour>();
                    bulletScript.SetDirection(parentTransform.right); // Using right direction relative to parentTransform
                }

            
        }
    }
}