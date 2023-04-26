using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemyBullet : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] PlayerMovement player;
    public GameObject enemyBulletPrefab;
    public float respawnTime = 0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(spawnEnemyWave());
    }

    private void spawnEnemyBullet()
    {
        GameObject enemyBulletSpawn = Instantiate(enemyBulletPrefab);
        enemyBulletSpawn.transform.position = new Vector2(screenBounds.x * 2, player.playerRb.transform.position.y);
    }

    IEnumerator spawnEnemyWave()
    {
        while (true)
        {
            if (gameController.gameStarted == true) {
                respawnTime = Random.Range(2, 7);
                spawnEnemyBullet();
            }
            yield return new WaitForSeconds(respawnTime);
        };
    }
}
