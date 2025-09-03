using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rigidbody2D.velocity.x != 0 || _rigidbody2D.velocity.y != 0)
        {
            _animator.SetBool(Structs.AnimationParameters.isWalking, true);
        }
        else
        {
            _animator.SetBool(Structs.AnimationParameters.isWalking, false);
        }
}
}
