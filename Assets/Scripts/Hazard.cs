using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float hazardSpeed;
    private Rigidbody2D hazardRb;
    [SerializeField] PointsValue pointsValue;
    //public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        //gameController = GameObject.Find("GameController").GetComponent<GameController>();

        hazardRb = GetComponent<Rigidbody2D>();
        hazardRb.velocity = new Vector2(-hazardSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (hazardRb.name == "Hazard(Clone)")
        {
            hazardSpeed = 14 + Mathf.FloorToInt(pointsValue.currentPoints * 0.01f);
            hazardRb.velocity = new Vector2(-hazardSpeed, 0);
        }
        else
        {
            hazardSpeed = 24 + Mathf.FloorToInt(pointsValue.currentPoints * 0.01f);
            hazardRb.velocity = new Vector2(-hazardSpeed, 0);
            Debug.Log(hazardRb.name);
        }

        if(hazardRb.position.x < -15)
        {
            Destroy(gameObject);
        }
    }

    
}
