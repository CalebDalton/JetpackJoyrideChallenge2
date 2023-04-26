using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameController gameController;
    public Rigidbody2D playerRb;
    [SerializeField] private int jumpHeight;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Transform bulletSpawn2;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && gameController.gameStarted == true)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpHeight);
            playerRb.gravityScale = 0;
            JetpackBullets();
        }
        else
        {
            playerRb.gravityScale = 5;
        }
    }

    private void JetpackBullets()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Instantiate(bulletPrefab, bulletSpawn2.position, bulletSpawn2.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            gameController.gameStarted = false;
        }
    }
}
