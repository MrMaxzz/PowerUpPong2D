using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public BallBounce ballBounce;
    public Player1 player1;
    public Player2 player2;
    public ScoreManager scoreManager;
    public float increaseSizeMultiplayer = 2f;
    bool powerUpFunctionOnlineP1;
    bool powerUpFunctionOnlineP2;
    bool revertSizeForP1;
    bool revertSizeForP2;
    public float increaseSizeDuration = 5f;

    public float decreaseSizeMultiplayer = 0.5f;
    public float decreaseSizeDuration = 5f;

    bool revertColorForP2;
    bool revertColorForP1;
    public float invisDuration = 5f;

    bool slowingP2;
    bool slowingP1;
    float normalRacketSpeed = 650f;
    public float slowDownDuration = 5f;
    public float slowDownMultiplayer = 0.5f;

    public bool P2HasAimbot;
    public bool P1HasAimbot;
    public float aimBotDuration = 5f;
    int P1FirstAimbot = 0;
    int P2FirstAimbot = 0;
    private void Update()
    {
        if (P1HasAimbot)
        {
            if (ballBounce.gameObject.transform.position.y >=3.9f)
            {
                player1.gameObject.transform.position = new Vector3(-7.5f, 3.9f,0f);
            }

            else if (ballBounce.gameObject.transform.position.y <= -3.9f)
            {
                player1.gameObject.transform.position = new Vector3(-7.5f, -3.9f, 0f);
            }

            else
            {
                player1.gameObject.transform.position = new Vector3(-7.5f, ballBounce.gameObject.transform.position.y, 0f);
            }
            
        }

        if (P2HasAimbot)
        {
            if (ballBounce.gameObject.transform.position.y >= 3.9f)
            {
                player2.gameObject.transform.position = new Vector3(7.5f, 3.9f, 0f);
            }

            else if (ballBounce.gameObject.transform.position.y <= -3.9f)
            {
                player2.gameObject.transform.position = new Vector3(7.5f, -3.9f, 0f);
            }
            else
            {
                player2.gameObject.transform.position = new Vector3(7.5f, ballBounce.gameObject.transform.position.y, 0f);
            }
            
        }
    }


    public void AimBot()
    {
        if (ballBounce.P1LastTouched && !powerUpFunctionOnlineP1)
        {
            scoreManager.numOfPowerUpsP1++;
            PlayerPrefs.SetInt("Player1NumOfPowerUps", scoreManager.numOfPowerUpsP1);
            scoreManager.player1PowerUpsText.text = "PowerUps picked up: " + scoreManager.numOfPowerUpsP1;

            P1HasAimbot = true;
            P1FirstAimbot++;
            if(P1FirstAimbot == 1)
            {
                Invoke("NoAimbotP1", aimBotDuration);
            }
            
        }

        if (ballBounce.P2LastTouched && !powerUpFunctionOnlineP2)
        {
            scoreManager.numOfPowerUpsP2++;
            PlayerPrefs.SetInt("Player2NumOfPowerUps", scoreManager.numOfPowerUpsP2);
            scoreManager.player2PowerUpsText.text = scoreManager.numOfPowerUpsP2 + " :PowerUps picked up";

            P2HasAimbot = true;
            P2FirstAimbot++;
            if (P2FirstAimbot == 1)
            {
                Invoke("NoAimbotP2", aimBotDuration);
            }

        }
    }

    void NoAimbotP1()
    {
        if (P1HasAimbot)
        {
            P1HasAimbot = false;
            powerUpFunctionOnlineP1 = false;
            P1FirstAimbot = 0;
        }
    }

    void NoAimbotP2()
    {
        if (P2HasAimbot)
        {
            P2HasAimbot = false;
            powerUpFunctionOnlineP2 = false;
            P2FirstAimbot = 0;
        }
    }
    public void SlowDown()
    {
        if (ballBounce.P1LastTouched && !slowingP2)
        {
            scoreManager.numOfPowerUpsP1++;
            PlayerPrefs.SetInt("Player1NumOfPowerUps", scoreManager.numOfPowerUpsP1);
            scoreManager.player1PowerUpsText.text = "PowerUps picked up: " + scoreManager.numOfPowerUpsP1;

            slowingP2 = true;
            player2.racketSpeed = player2.racketSpeed * slowDownMultiplayer;
            Invoke("NormalSpeedP2", slowDownDuration);
            
        }

        if(ballBounce.P2LastTouched && !slowingP1)
        {
            scoreManager.numOfPowerUpsP2++;
            PlayerPrefs.SetInt("Player2NumOfPowerUps", scoreManager.numOfPowerUpsP2);
            scoreManager.player2PowerUpsText.text = scoreManager.numOfPowerUpsP2 + " :PowerUps picked up";

            slowingP1 = true;
            player1.racketSpeed = player1.racketSpeed * slowDownMultiplayer;
            Invoke("NormalSpeedP1", slowDownDuration);
            
        }

    }

    void NormalSpeedP2()
    {
        if (slowingP2)
        {
            player2.racketSpeed = normalRacketSpeed;
            
        }
    }

    void NormalSpeedP1()
    {
        if (slowingP1)
        {
            player1.racketSpeed = normalRacketSpeed;
            
        }
    }
         
public void PowerUp_Increase()
    {
        if (ballBounce.P1LastTouched && !powerUpFunctionOnlineP1)
        {
            scoreManager.numOfPowerUpsP1++;
            PlayerPrefs.SetInt("Player1NumOfPowerUps", scoreManager.numOfPowerUpsP1);
            scoreManager.player1PowerUpsText.text = "PowerUps picked up: " + scoreManager.numOfPowerUpsP1;

            revertSizeForP1 = true;
            player1.gameObject.transform.localScale += new Vector3(0f, 1 * increaseSizeMultiplayer, 0f);
            Debug.Log("Player 1 did powerUpFunctioin");
            Invoke("PowerUpSizeNormalP1", increaseSizeDuration);
            powerUpFunctionOnlineP1 = true;

        }

        else if (ballBounce.P2LastTouched && !powerUpFunctionOnlineP2)
        {
            scoreManager.numOfPowerUpsP2++;
            PlayerPrefs.SetInt("Player2NumOfPowerUps", scoreManager.numOfPowerUpsP2);
            scoreManager.player2PowerUpsText.text = scoreManager.numOfPowerUpsP2 + " :PowerUps picked up";

            revertSizeForP2 = true;
            player2.gameObject.transform.localScale += new Vector3(0f, 1 * increaseSizeMultiplayer, 0f);
            Debug.Log("Player 2 did powerUpFunctioin");
            powerUpFunctionOnlineP2 = true;
            Invoke("PowerUpSizeNormalP2", increaseSizeDuration);

        }
        
        
    }

    public void Invisible()
    {
        if (ballBounce.P1LastTouched)
        {
            scoreManager.numOfPowerUpsP1++;
            PlayerPrefs.SetInt("Player1NumOfPowerUps", scoreManager.numOfPowerUpsP1);
            scoreManager.player1PowerUpsText.text = "PowerUps picked up: " + scoreManager.numOfPowerUpsP1;

            revertColorForP2 = true;
            player2.GetComponent<Renderer>().material.color = new Color(0.06603771f, 0.06603771f, 0.06603771f);
            Invoke("NoInvis", invisDuration);
            Debug.Log("Player 1 did invis");
        }

        else if (ballBounce.P2LastTouched)
        {
            scoreManager.numOfPowerUpsP2++;
            PlayerPrefs.SetInt("Player2NumOfPowerUps", scoreManager.numOfPowerUpsP2);
            scoreManager.player2PowerUpsText.text = scoreManager.numOfPowerUpsP2 + " :PowerUps picked up";

            revertColorForP1 = true;
            player1.GetComponent<Renderer>().material.color = new Color(0.06603771f, 0.06603771f, 0.06603771f);
            Invoke("NoInvis", invisDuration);
            Debug.Log("Player 2 did invis");
        }
    }

    void NoInvis()
    {
        if (revertColorForP1)
        {
            player1.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
            revertColorForP1 = false;
            
        }

        if (revertColorForP2)
        {
            player2.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
            revertColorForP2 = false;
            
        }
    }

    public void DecreaseSize()
    {
        if (ballBounce.P1LastTouched && !powerUpFunctionOnlineP2)
        {
            scoreManager.numOfPowerUpsP1++;
            PlayerPrefs.SetInt("Player1NumOfPowerUps", scoreManager.numOfPowerUpsP1);
            scoreManager.player1PowerUpsText.text = "PowerUps picked up: " + scoreManager.numOfPowerUpsP1;

            revertSizeForP2 = true;
            player2.gameObject.transform.localScale -= new Vector3(0f, 1 * decreaseSizeMultiplayer, 0f);
            Invoke("PowerUpSizeNormalP2", decreaseSizeDuration);
            powerUpFunctionOnlineP2 = true;
            Debug.Log("Player 1 did Decrease");
        }

        else if (ballBounce.P2LastTouched && !powerUpFunctionOnlineP1)
        {
            scoreManager.numOfPowerUpsP2++;
            PlayerPrefs.SetInt("Player2NumOfPowerUps", scoreManager.numOfPowerUpsP2);
            scoreManager.player2PowerUpsText.text = scoreManager.numOfPowerUpsP2 + " :PowerUps picked up";

            revertSizeForP1 = true;
            player1.gameObject.transform.localScale -= new Vector3(0f, 1 * decreaseSizeMultiplayer, 0f);
            Invoke("PowerUpSizeNormalP1", decreaseSizeDuration);
            powerUpFunctionOnlineP1 = true;
            Debug.Log("Player 2 did Decrease");
        }
    }

    void PowerUpSizeNormalP1()
    {
        if (revertSizeForP1)
        {
            player1.gameObject.transform.localScale = Vector3.one;
            revertSizeForP1 = false;
            powerUpFunctionOnlineP1 = false;
        }


    }
    void PowerUpSizeNormalP2()
    {
        if (revertSizeForP2)
        {
            player2.gameObject.transform.localScale = Vector3.one;
            revertSizeForP2 = false;
            powerUpFunctionOnlineP2 = false;
        }
    }
    
}
