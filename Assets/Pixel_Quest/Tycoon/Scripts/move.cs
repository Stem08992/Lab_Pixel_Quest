using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    public int speed = 5;
    public float xMultiplier = 4;

    // Start is called before the first frame update
    void Start()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        float xInput = Input.GetAxis("Horizontal");
        if (xInput > 0) {sprite.flipX = true;}
        else if (xInput < 0) {sprite.flipX= false;}
        rb.velocity= new Vector2(xMultiplier*xInput, rb.velocity.y);

    }


    
}
