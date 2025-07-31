using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
     void Update()
    {

        // if (rb.velocity.x == 0)
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal ==0)
        {
            animator.SetBool("IsWalking", false);
        }
        else
        {
            animator.SetBool("IsWalking", true);
        }
    }
}
