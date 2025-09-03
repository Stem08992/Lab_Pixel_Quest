using UnityEngine;

public class HW2PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private float _xSpeed;
    private float _ySpeed;

    public float speed;

    private string InputX = "Horizontal";
    private string InputY = "Vertical";

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        _xSpeed = Input.GetAxis("Horizontal");
        _ySpeed = Input.GetAxis("Vertical");

        _rigidbody2D.velocity = new Vector2(_xSpeed, _ySpeed) * speed;
    }
}
