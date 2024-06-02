using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilePulling : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<ProyectileBehavior>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
