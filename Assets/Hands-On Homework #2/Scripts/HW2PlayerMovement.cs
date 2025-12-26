using UnityEngine;

public class HW2PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private float _YSpeed;
    private float _XSpeed;

    public float speed = 3;

    private string InputX = "Horizontal";
    private string InputY = "Vertical";
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _XSpeed = Input.GetAxis(InputX);
        _YSpeed = Input.GetAxis(InputY);

        _rigidbody2D.velocity = new Vector2(_XSpeed, _YSpeed) * speed;

    }
}
