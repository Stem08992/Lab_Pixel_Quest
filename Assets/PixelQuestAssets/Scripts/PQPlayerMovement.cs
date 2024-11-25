using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PQPlayerMovement : MonoBehaviour
{
    public int xMul = 3;                        // Multiplies the player's input by the given speed.
    private Rigidbody2D rigidbody2D;            // Controls the velocity of the player.
    private SpriteRenderer spriteRenderer;      // Controls the image of the player.
    private const string AxisX = "Horizontal";  // Keeps track of the string used for getting player input.

    // Start is called before the first frame update
    // Connects the Rigidbody and SpriteRenderer to their respective components.
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

    }

    // Updates the player state.
    void Update()
    {
        // Gets player input from A/D or Left Arrow/Right Arrow keys.
        float xVelocity = Input.GetAxis(AxisX);

        // Flips the player sprite to face the direction of movement. 
        if (xVelocity > 0){
            spriteRenderer.flipX = false;
        }
        else{
            spriteRenderer.flipX = true; 
        }

        // Saves player input to the Rigidbody and makes the player move at the given speed.
        rigidbody2D.velocity = new Vector2 (xMul * xVelocity, rigidbody2D.velocity.y);

    }
}
