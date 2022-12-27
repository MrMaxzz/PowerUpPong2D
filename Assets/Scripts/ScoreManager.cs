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

    public TextMeshProUGUI player1MatchWonText;
    public TextMeshProUGUI player2MatchWonText;
    public TextMeshProUGUI player1BallsWonText;
    public TextMeshProUGUI player2BallsWonText;
    int player1MatchesWon = 0;
    int player2MatchesWon = 0;
    int player1BallsWon = 0;
    int player2BallsWon = 0;

    public TextMeshProUGUI player1PowerUpsText;
    public TextMeshProUGUI player2PowerUpsText;
    public int numOfPowerUpsP1 = 0;
    public int numOfPowerUpsP2 = 0;

    private void Awake()
    {
        player1MatchesWon = PlayerPrefs.GetInt("Player1MatchesWon", 0);
        player2MatchesWon = PlayerPrefs.GetInt("Player2MatchesWon", 0);
        player1BallsWon = PlayerPrefs.GetInt("Player1BallsWon", 0);
        player2BallsWon = PlayerPrefs.GetInt("Player2BallsWon", 0);
        numOfPowerUpsP1 = PlayerPrefs.GetInt("Player1NumOfPowerUps", 0);
        numOfPowerUpsP2 = PlayerPrefs.GetInt("Player2NumOfPowerUps", 0);

        player1PowerUpsText.text = "PowerUps picked up: " + numOfPowerUpsP1.ToString();
        player2PowerUpsText.text = numOfPowerUpsP2.ToString() + " :PowerUps picked up";

        player1MatchWonText.text = "Matches won: " + player1MatchesWon.ToString();
        player1BallsWonText.text = "Total balls won: " + player1BallsWon.ToString();
        player2MatchWonText.text = player2MatchesWon.ToString() + " :Matches won";
        player2BallsWonText.text = player2BallsWon.ToString() + " :Total balls won";



    }
    public void Player1Goal()
    {
        player1Score++;
        player1BallsWon++;
        PlayerPrefs.SetInt("Player1BallsWon", player1BallsWon);
        player1BallsWonText.text = "Total balls won: " + player1BallsWon.ToString();
        playerScore1Text.text = player1Score.ToString();
        ballMovement.firstRound = false;
        CheckScore();

    }

    public void Player2Goal()
    {
        player2BallsWon++;
        PlayerPrefs.SetInt("Player2BallsWon", player2BallsWon);
        player2BallsWonText.text = player2BallsWon.ToString() + " :Total balls won";
        player2Score++;
        playerScore2Text.text = player2Score.ToString();
        ballMovement.firstRound = false;
        CheckScore();
    }

    void CheckScore()
    {
        if(player1Score == scoreToReach)
        {
            player1MatchesWon++;
            PlayerPrefs.SetInt("Player1MatchesWon", player1MatchesWon);
            player1MatchWonText.text = "Matches won: " + player1MatchesWon.ToString();
            StartCoroutine("NewScene");
            Time.timeScale = 0;

        }

        else if (player2Score == scoreToReach)
        {
            player2MatchesWon++;
            PlayerPrefs.SetInt("Player2MatchesWon", player2MatchesWon);
            player2MatchWonText.text = player2MatchesWon.ToString() + " :Matches won";
            StartCoroutine("NewScene");
            Time.timeScale = 0;

        }
    }
    IEnumerator NewScene()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
   
}
