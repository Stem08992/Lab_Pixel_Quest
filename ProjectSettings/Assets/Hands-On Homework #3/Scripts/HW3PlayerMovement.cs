using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HW3PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigRigidbody2D;
    private HW3PlayerDialogue _hw3PlayerDialogue;
    private float _xVelocity = 0f;
    private float _yVelocity = 0f;
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        _rigRigidbody2D = GetComponent<Rigidbody2D>();
        _hw3PlayerDialogue = GetComponent<HW3PlayerDialogue>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (_hw3PlayerDialogue.IsSpeaking())
        {
            _xVelocity = 0;
            _yVelocity = 0;
        }
        else
        {
            _xVelocity = Input.GetAxis(HW3Structs.Input.horizontal);
            _yVelocity = Input.GetAxis(HW3Structs.Input.vertical);
        }

        
        _rigRigidbody2D.velocity = new Vector2(_xVelocity, _yVelocity) * speed; 
    }
}
