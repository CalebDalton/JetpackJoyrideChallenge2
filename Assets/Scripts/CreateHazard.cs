using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHazard : MonoBehaviour
{
    [SerializeField] GameController gameController;
    public GameObject hazardPrefab;
    public float respawnTime = 1f;
    private Vector2 screenBounds;
    int count = 0;
    GameObject hazardObject;
    
        // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(hazardWave());
    }

    private void spawnHazard() 
    {
        
        if (count == 2)
        {
            hazardObject = Instantiate(hazardPrefab);
            hazardObject.transform.Rotate(0f, 0f, 30f);
            count = 0;
        }
        else
        {
            hazardObject = Instantiate(hazardPrefab);
            count++;
        }

        hazardObject.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y + 1, screenBounds.y - 1));
    }

    IEnumerator hazardWave()
    {
        while (true)
        {
            
            if (gameController.gameStarted == true) {
                Debug.Log("Running hazard creation");
                spawnHazard();
            }
            yield return new WaitForSeconds(respawnTime);
        }
    }
}
