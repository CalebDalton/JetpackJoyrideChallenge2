using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsTracker : MonoBehaviour
{
    public TextMeshProUGUI pointsUI;
    public TextMeshProUGUI highScore;
    public PointsValue pointsValue;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        pointsValue.currentPoints = 0;
        pointsUI = GameObject.Find("Points").GetComponent<TextMeshProUGUI>();
        highScore = GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();
        highScore.text = "High Score: " + Mathf.Floor(pointsValue.highScore).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.gameStarted == true)
        {
            pointsValue.currentPoints = pointsValue.currentPoints + 0.07f;
            pointsUI.text = "Score: " + Mathf.Floor(pointsValue.currentPoints).ToString();

            if (pointsValue.highScore < pointsValue.currentPoints)
            {
                pointsValue.highScore = pointsValue.currentPoints;
                highScore.text = "High Score: " + Mathf.Floor(pointsValue.highScore).ToString();
            }
            else
            {
                highScore.text = "High Score: " + Mathf.Floor(pointsValue.highScore).ToString();
            }
        }
    }
}
