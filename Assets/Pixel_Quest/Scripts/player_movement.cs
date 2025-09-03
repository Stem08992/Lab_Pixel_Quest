using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr1;
    public int speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        sr1 = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        if (xInput <0)
        {
            sr1.flipX = true;
        }
        else if (xInput >0)
        {
            sr1 .flipX = false;
        }
        
        rb.velocity = new Vector2(xInput*speed, yInput*speed);
        

    }
    
}
