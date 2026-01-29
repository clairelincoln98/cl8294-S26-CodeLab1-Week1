using System;
using UnityEngine;
using TMPro;
using UnityEditor.Animations;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; //rigid body component 
    private Vector2 velocity; 
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    private bool isGrounded;
    private Vector2 startingPosition;
    private float jumpHeldTimer;
    [SerializeField] private float jumpHeldTimerMax;
    private bool jumpButtonHeld;
    private bool justAirJumped;
    private SpriteRenderer sprite;
    public float coinCount = 0;
    
    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //prevents a double jump in air
        {
            velocity.y = jumpForce;
            jumpHeldTimer = jumpHeldTimerMax;
        }

        if (Input.GetKey(KeyCode.Space)) //checks if player hits space
        {
            jumpButtonHeld = true; //is a condition that checks if the button is held down
        }
        else
        {
            jumpButtonHeld = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded == false)
        {
            velocity.y = jumpForce;
            jumpHeldTimer = jumpHeldTimerMax; //lets the player control the force of the jump by holding space
        }
    }

    private void FixedUpdate()
    {
        if (coinCount < 5) //this big if statement controls the end of the game. When the player hits 6 coins, the game ends
        {
            if (!isGrounded)
            {
                if (jumpButtonHeld)
                {
                    jumpHeldTimer -= Time.fixedDeltaTime;
                }

                if (!jumpButtonHeld || jumpHeldTimer <= 0)
                {
                    velocity.y -= gravity * Time.fixedDeltaTime;
                }
            }

            velocity.x = 0; //set velocity x to zero
            //set velocity to -1, 0, or 1 depending on keys held
            if (Input.GetKey(KeyCode.A))
            {
                
                velocity.x -= speed;
                
            }

            if (Input.GetKey(KeyCode.D))
            {
               
                velocity.x += speed;

            }
           
            Vector2 newPosition = rb.position + velocity * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);

            if (transform.position.y < -10)
            {
                transform.position = startingPosition;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("coin")) //this checks if the player runs into a coin
        {
            Debug.Log("collider working");
            coinCount += 1; //adds a coin to coin count
            print(coinCount); //checks if this is working
            Destroy(other.gameObject); //removes the coin after player picks it up
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
        
    }
    
    
}