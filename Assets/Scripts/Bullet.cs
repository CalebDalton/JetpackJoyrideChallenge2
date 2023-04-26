using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float charBulletSpeed = 20f;
    public Rigidbody2D bulletObject;

    private void Start()
    {
        bulletObject.velocity = -transform.up * charBulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Bullet"))
        {
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
