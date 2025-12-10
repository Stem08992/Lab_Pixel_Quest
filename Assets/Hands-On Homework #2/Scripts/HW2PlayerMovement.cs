using UnityEngine;
public class HW2PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float xSpeed;
    private float ySpeed;


    public float speed = 3;

    private string InputX = "Horizontal";
    private string InputY = "Vertical";

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        xSpeed = Input.GetAxis("Horizontal");
        ySpeed = Input.GetAxis("Vertical");

        _rb.velocity = new Vector2(xSpeed, ySpeed) * speed;
        

    }
}
