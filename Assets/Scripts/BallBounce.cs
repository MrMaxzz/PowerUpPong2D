using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BallBounce : MonoBehaviour
{
    public GameObject hitSFX;
    public PowerUpManager powerUpManager;
    public BallMovement ballMovement;
    public ScoreManager scoreManager;
    public bool P1LastTouched;
    public bool P2LastTouched;

    void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;

        if(collision.gameObject.name == "Player1")
        {
            positionX = 1;
        }

        else
        {
            positionX = -1;
        }

        float positionY = (ballPosition.y - racketPosition.y) / racketHeight;

        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1")
        {
            P1LastTouched = true;
            P2LastTouched = false;
        }

        else if(collision.gameObject.name == "Player2")
        {
            P1LastTouched = false;
            P2LastTouched = true;
        }

        if(collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            Bounce(collision);
        }

        else if(collision.gameObject.name == "RightBorder")
        {
            scoreManager.Player1Goal();
            ballMovement.player1Start = false;
            StartCoroutine(ballMovement.Launch());
        }

        else if (collision.gameObject.name == "LeftBorder")
        {
            scoreManager.Player2Goal();
            ballMovement.player1Start = true;
            StartCoroutine(ballMovement.Launch());
        }
        Instantiate(hitSFX, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PowerUp")
        {
            if (collision.gameObject.name == "IncreaseSize(Clone)")
            {
                Debug.Log("Kolliderade med IncreaseSize");
                powerUpManager.PowerUp_Increase();
            }
            
            else if (collision.gameObject.name == "DecreaseSizePowerUp(Clone)")
            {
                powerUpManager.DecreaseSize();
            }

            else if (collision.gameObject.name == "InvisPowerUp(Clone)")
            {
                powerUpManager.Invisible();
            }

            else if (collision.gameObject.name == "SlowDownPowerUp(Clone)")
            {
                powerUpManager.SlowDown();
            }

            else if (collision.gameObject.name == "AimbotPowerUp(Clone)")
            {
                powerUpManager.AimBot();
            }

            
            Destroy(collision.gameObject);
        }
    }
}
