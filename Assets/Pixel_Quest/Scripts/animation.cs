using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
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
            _animator.SetBool("iswalking", false);

        }
        else
        {
            _animator.SetBool("iswalking", true);
        }
    }
}
