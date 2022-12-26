using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSizePowerUp : MonoBehaviour
{
    public BallBounce ballBounce;
    public GameObject ball;
    public Player1 player1;
    public GameObject player1Obj;
    public Player2 player2;
    public GameObject player2Obj;

    private void Awake()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");

        if(ball == null)
        {
            Debug.Log("ball == null");
        }

        ballBounce = ball.GetComponent<BallBounce>();

        if(ballBounce == null)
        {
            Debug.Log("ballBounce == null");
        }
        player1Obj = GameObject.FindGameObjectWithTag("Player1");

        player1 = player1Obj.GetComponent<Player1>();

        player2Obj = GameObject.FindGameObjectWithTag("Player2");

        player2 = player2Obj.GetComponent<Player2>();
    }
   
    
    public void powerUp_Increase()
    {
        if (ballBounce.P1LastTouched)
        {
            player1.gameObject.transform.localScale += new Vector3(0f, 10f, 0f);
            Debug.Log("Player 1 did powerUpFunctioin");
            
        }
        else if (ballBounce.P2LastTouched)
        {
            player2.gameObject.transform.localScale += new Vector3(0f, 10f, 0f);
            Debug.Log("Player 2 did powerUpFunctioin");
        }
        
    }

}
