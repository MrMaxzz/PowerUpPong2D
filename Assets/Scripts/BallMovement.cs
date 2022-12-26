using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;

    public bool player1Start;
    public bool firstRound;

    int launchDirection;

    bool validDirection = false;

    int hitCounter = 0;

    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        firstRound = true;
        while (!validDirection)
        {
            launchDirection = Random.Range(-1, 2);
            if(launchDirection != 0)
            {
                validDirection = true;
            }
        }
        
        StartCoroutine(Launch());
    }

    void RestartBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    public IEnumerator Launch()
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1);
        if (player1Start && !firstRound)
        {
            MoveBall(new Vector2(-1, 0));
        }

        else if (!player1Start && !firstRound)
        {
            MoveBall(new Vector2(1, 0));
        }
        else if(firstRound)
        {
            MoveBall(new Vector2(launchDirection, 0));
        }
    }
        

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;

        float ballSpeed = startSpeed + hitCounter * extraSpeed;

        rb.velocity = direction * ballSpeed;
    }

    public void IncreaseHitCounter()
    {
        if(hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }
}
