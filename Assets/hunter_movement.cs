using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hunter_movement : MonoBehaviour {
   private Rigidbody2D rb;
    // Start is called before the first frame update

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
        }


    }
}
