using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class animatation : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (_rigidbody2D.velocity.x == 0)
        {
            animator.SetBool("isWalking", false);

            
   
       
        }
        else
        {
            animator.SetBool("isWalking",true);
        }  
    }
}
