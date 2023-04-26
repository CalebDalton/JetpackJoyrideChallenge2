using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool gameStarted = false;
    public bool gameHasStarted = false;
    [SerializeField] PointsValue pointsValue;

    private void Update()
    {
        if (gameStarted == true)
        {
            GameObject.FindGameObjectWithTag("Button").SetActive(false);
        }

        if(gameHasStarted == true && gameStarted == false)
        {
            var obj = GameObject.Find("ButtonCanvas").transform.GetChild(0);
            obj.gameObject.SetActive(true);
        }
    }

    public void PlayGame()
    {
        if(gameHasStarted == true)
        { 
            pointsValue.currentPoints = 0;
            gameStarted = true;
        }
        if (gameStarted == false)
        {
            gameStarted = true;
            gameHasStarted = true;
        }
    }

}
