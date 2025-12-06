using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGamePlayerJump : MonoBehaviour
{
    Rigidbody2D rb;
    public float JumpForce = 10f;
    public float FallForce = 2f;

    //Capsule
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;

    //Ground Check
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;
    private bool _waterCheck = false;
    private string _waterTag = "Water";

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _groundCheck = Physics2D.OverlapCapsule(feetCollider.position,
        new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal,
        0, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.UpArrow)) && (_groundCheck || _waterCheck))
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_waterTag)) { _waterCheck = true; }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_waterTag)) { _waterCheck = false; }
    }
}
