using UnityEngine;

public class HW2PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float xSpeed;
    private float ySpeed;

    public float speed = 3;

    private string InputX = "Horizontal";
    private string InputY = "Vertical"; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        xSpeed = Input.GetAxis(InputX);
        ySpeed = Input.GetAxis(InputY);

        rb.velocity = new Vector2 (xSpeed, ySpeed) * speed;
    }
}
