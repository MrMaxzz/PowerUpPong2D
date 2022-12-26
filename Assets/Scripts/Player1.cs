using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float racketSpeed;
    public PowerUpManager powerUpManager;

    [SerializeField] public Rigidbody2D rb;
    public Vector2 racketDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!powerUpManager.P1HasAimbot)
        {
            float directionY = Input.GetAxisRaw("Vertical");
            racketDirection = new Vector2(0, directionY).normalized;
        }
        

        
    }

    private void FixedUpdate()
    {
        if (!powerUpManager.P1HasAimbot)
        {
            rb.velocity = racketDirection * racketSpeed * Time.deltaTime;
        }
        
    }
}
