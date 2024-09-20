using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() // Use FixedUpdate for physics-related movement
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        float moveVertical = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;

        // Create a movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Move the player using Rigidbody
        rb.MovePosition(rb.position + movement);
    }
}
