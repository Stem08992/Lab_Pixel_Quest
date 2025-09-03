using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            _anim.SetBool("PlayerWalk", false);
            _anim.SetBool("PlayerDash", true);
            _anim.SetBool("PlayerSlide", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _anim.SetBool("PlayerWalk", false);
            _anim.SetBool("PlayerDash", false);
            _anim.SetBool("PlayerSlide", true);
        }
        else if (_rb.velocity.x != 0)
        {
            _anim.SetBool("PlayerWalk", true);
            _anim.SetBool("PlayerDash", false);
            _anim.SetBool("PlayerSlide", false);
        }
        else
        {
            _anim.SetBool("PlayerWalk", false);
            _anim.SetBool("PlayerDash", false);
            _anim.SetBool("PlayerSlide", false);
        }
    }
}

