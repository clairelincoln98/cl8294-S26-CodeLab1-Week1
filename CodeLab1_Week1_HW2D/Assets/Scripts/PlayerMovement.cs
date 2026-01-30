using System;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 velocity;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    private bool isGrounded;
    private Vector2 startingPosition;
    private int coinCount = 0;
    public TMP_Text youWin;

    
    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpForce;
            
        }
        

        if (coinCount == 5)
        {
            youWin.text = "YOU WIN";
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded == false) //prevents double jump
        {
            velocity.y = jumpForce;
        }
    }

    private void FixedUpdate()
    {
        if (coinCount < 5) //checks that game is still going, if player reaches 5 the game stops
        {
            if (!isGrounded)
            {
               
                velocity.y -= gravity * Time.fixedDeltaTime; //the player is falling if not grounded
              
            }

            velocity.x = 0; //set velocity x to zero
            //set velocity to -1, 0, or 1 depending on keys held
            if (Input.GetKey(KeyCode.A)) //player is going left when player hits A key
            {
                
                velocity.x -= speed;
             
                
            }

            if (Input.GetKey(KeyCode.D)) //player is going right when player hits D key
            {
               
                velocity.x += speed;
                

            }
          
            
            Vector2 newPosition = rb.position + velocity * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        
        if (transform.position.y < -10) // let's the player restart if they miss a platform
            {
                transform.position = startingPosition;
            }
        }
    } 
    
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Platform")) //checks if the player is on a platform
        {
            isGrounded = true; //tells program that the player is grounded
        }
        
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coin")) //check if the player runs into coin
        {
            Debug.Log("collider working");
            coinCount += 1; //adds a point the coin count
            print(coinCount);
            Destroy(other.gameObject); //destroys coin once the player gets it
        } 
    }
    
    
}