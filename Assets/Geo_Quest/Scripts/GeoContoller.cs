using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoContoller : MonoBehaviour {
    public string nextLevel = "Level2";
    
    public float speed = 4f;
    public float JumpForce = 10f; 
    
    public SpriteRenderer sr;
    private Rigidbody2D rb2d;
    
    // Capsule
    public float CapsuleHeight = 0.25f; 
    public float CapsuleRadius = 0.08f;

    // Ground Check
    public Transform feetCollider; // FeetCollider (Transform)
    public LayerMask groundMask; // Serializable
    private bool _groundCheck;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>(); 
        sr = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update() {
        float xInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(xInput * speed, rb2d.velocity.y);

        // Checks if player is touching ground
        _groundCheck = Physics2D.OverlapCapsule(point: feetCollider.position, 
            size: new Vector2(CapsuleHeight, CapsuleRadius),
            CapsuleDirection2D.Vertical, angle: 0, groundMask); 

        // Checks if player is trying to jump/can jump
        if (Input.GetKeyDown(KeyCode.Space) && _groundCheck) { 
            rb2d.velocity = new Vector2(rb2d.velocity.x, JumpForce); 
        } 

        if (xInput > 0) { sr.flipX = true; }
        else { sr.flipX = false; }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");

        switch (collision.tag) {
            case "Death": {
                string thisLevel = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(thisLevel);
                break;
            }
            case "Finish": {
                SceneManager.LoadScene(nextLevel);
                break;
            }
    }
    }
}
