using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private Transform ball;
    [SerializeField] private int point;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    private void Update()
    {
        if(transform.position.y + 12.5f >= ball.position.y)
        {
            Destroy(this.gameObject);

            gameManager.GameScore(point);
        }
    }
}
