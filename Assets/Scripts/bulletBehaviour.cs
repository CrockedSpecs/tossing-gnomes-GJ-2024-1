using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    private float shootSpeed;
    private float shootRange;
    private float bulletDamage;
    private bool isMoving;
    private Vector3 direction;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
        startPos = transform.position;

        // Assuming the bullet is instantiated by the turret
        turretBehaviour turretScript = transform.parent.GetComponent<turretBehaviour>();
        shootSpeed = turretScript.shootSpeed;
        shootRange = turretScript.shootRange;
        bulletDamage = turretScript.bulletDamage;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    // Set the direction of the bullet
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    // Handles the movement of the bullet
    void Movement()
    {
        if (isMoving)
        {
            transform.Translate(direction * shootSpeed * Time.deltaTime, Space.World);
        }
        if (Vector3.Distance(startPos, transform.position) >= shootRange)
        {
            isMoving = false;
            Destroy(gameObject);
        }
    }

    //private void onTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}