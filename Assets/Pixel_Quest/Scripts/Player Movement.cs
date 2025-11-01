using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D _rigidbody2D;
    public int speed = 4;
    private SpriteRenderer _spriteRenderer;
    public float xMultiplier = 4;
    
    // Start is called before the first frame update
    public void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>(); 
        _spriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
    }
    
  

    // Update is called once per frame
    private void Update()
    {
       
        float xMovement = Input.GetAxis("Horizontal");
       

      
        if (xMovement > 0) { _spriteRenderer.flipX = true; }
        else if (xMovement <0) { _spriteRenderer.flipX= false; }



            _rigidbody2D.velocity = new Vector2(xMultiplier * xMovement, _rigidbody2D.velocity.y);


    }
}
