using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 720f;  // Rotation speed in degrees per second
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;  // Prevents unwanted rotations from physics interactions
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized * speed;

        // Apply movement via velocity
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Rotate the player to face the movement direction if there's input
        // if (movement != Vector3.zero)
        // {
        //     Quaternion targetRotation = Quaternion.LookRotation(movement);
        //     rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        // }
    }
}
