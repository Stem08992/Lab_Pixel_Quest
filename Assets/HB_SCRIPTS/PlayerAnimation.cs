using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");

        if (rb.velocity.x != 0)
        {
            animator.SetBool("IsWalking", true);

            if ( xInput == -1)
            {
                animator.SetBool("IsWalkingLeft", true);
                animator.SetBool("IsWalkingRight", false);
                animator.SetBool("IsFacingLeft", true);
            }
            else if (xInput == 1)
            {
                animator.SetBool("IsWalkingLeft", false);
                animator.SetBool("IsWalkingRight", true);
                animator.SetBool("IsFacingRight", true);
            }
        }
        else
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsWalkingLeft", false);
            animator.SetBool("IsWalkingRight", false);
          
        }

        //if(Input.GetKeyDown(KeyCode.F))
        //{
        //    animator.SetBool("IsAttacking", true);
        //}

        //else
        //{
        //    animator.SetBool("IsAttacking", false);
        //}
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("attack");
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            animator.SetTrigger("back");
            animator.SetBool("IsFacingLeft", false);
            animator.SetBool("IsFacingRight", false);

        }
    }
}
