using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playermove : MonoBehaviour
{ int var1 = 3;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    
    int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        

        sr = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }   

    // Update is called once per frame
     void Update()
    {
        
      
        
       float xInput = Input.GetAxis("Horizontal");
       if (xInput > 0 )
        {
            sr.flipX = false;
        }
        if (xInput < 0)
        {
            sr.flipX = true;
        }
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

    }
          

         



}
