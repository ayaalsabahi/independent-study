using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 720f;  // Rotation speed in degrees per second
    private Rigidbody rb;
    private bool canMove; 

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        canMove = true; 
    }

    void FixedUpdate()
    {
        if(canMove){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized * speed;

        // Apply movement via velocity
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        }
        else{
            rb.velocity =  new Vector3(0, 0, 0);
        }
    }


    //locks the player movement
    public void switchMovement(){
        canMove = !canMove; 
    }
}
