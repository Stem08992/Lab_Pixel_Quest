using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed

    void Update()
    {
        float moveInput = 0f;

        // Check for left or right input
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f; // Move left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f; // Move right
        }

        // Calculate movement
        Vector3 movement = new Vector3(moveInput, 0f, 0f) * speed * Time.deltaTime;

        // Apply movement
        transform.Translate(movement);







    }
}