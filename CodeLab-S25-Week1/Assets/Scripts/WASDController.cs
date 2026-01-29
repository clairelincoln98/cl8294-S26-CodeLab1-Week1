using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class WASDController : MonoBehaviour
{ 
    Rigidbody rb; //rigid body for the game object that this script is attached to

    public float moveForce = 10f; //the force we will add to a game object to make it move

    public Key keyUp = Key.W; //keyUp for the new input system
    public  Key keyDown = Key.S; //keyDown for the new input system
    public   Key keyLeft = Key.A; //keyLeft for the new input system
    public   Key keyRight = Key.D; //keyRight for the new input system

    Keyboard keyboard = Keyboard.current; //get the keyboard input for this device

    private int integer;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //searches for a component of this type on this gameobject
    }

    void FixedUpdate()
    {

        if (keyboard[keyUp].isPressed)
        {
            rb.AddForce(Vector3.up * moveForce, ForceMode.Acceleration); //give the object an upward force
        }
        
        if (keyboard[keyDown].isPressed)
        {
            rb.AddForce(Vector3.down * moveForce, ForceMode.Acceleration); //give the object an upward force
        }
        
        if (keyboard[keyRight].isPressed)
        {
            rb.AddForce(Vector3.right * moveForce, ForceMode.Acceleration); //give the object an upward force
        }
        
        if (keyboard[keyLeft].isPressed)
        {
            rb.AddForce(Vector3.right * moveForce, ForceMode.Acceleration); //give the object an upward force
        }
        
        
        
     // if(Input.GetKey(KeyCode.S))
    //    {
     //  rb.AddForce(Vector3.down * moveForce, ForceMode.Acceleration); //give the object a downward force
   //     }
    }
}