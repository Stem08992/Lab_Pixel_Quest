using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
   
       if (_rigidbody2D.velocity.x == 0)
        {
            _animator.SetBool("isWalking",false);
                
        }
       
       else { _animator.SetBool( "isWalking",true);
        }


        



    }
}
