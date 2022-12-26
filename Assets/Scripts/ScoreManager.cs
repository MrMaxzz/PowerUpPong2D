using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int scoreToReach;

    public BallMovement ballMovement;
    int player1Score = 0;
    int player2Score = 0;

    public TextMeshProUGUI playerScore1Text;
    public TextMeshProUGUI playerScore2Text;

    public void Player1Goal()
    {
        player1Score++;
        playerScore1Text.text = player1Score.ToString();
        ballMovement.firstRound = false;
        CheckScore();

    }

    public void Player2Goal()
    {
        player2Score++;
        playerScore2Text.text = player2Score.ToString();
        ballMovement.firstRound = false;
        CheckScore();
    }

    void CheckScore()
    {
        if(player1Score == scoreToReach || player2Score == scoreToReach)
        {
            SceneManager.LoadScene(2);
        }
    }
}
