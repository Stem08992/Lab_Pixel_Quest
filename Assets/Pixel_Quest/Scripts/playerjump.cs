using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class playerjump : MonoBehaviour
{
    public float jumpforce = 10f;
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;
    private float fallforce = 4;
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundcheck;
    private Vector2 gravityforce;
    private Rigidbody2D _rigidbody2d;
    private bool waterCheck;
    // Start is called before the first frame update
    void Start()
    {
        gravityforce = new Vector2(0f, Physics2D.gravity.y);
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Water") { waterCheck=false; }
          

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Water") { waterCheck =true; }

    }

    // Update is called once per frame
    void Update()
    {          
        _groundcheck = Physics2D.OverlapCapsule(point: feetCollider.position,
       size: new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal,0,groundMask);
         
        if (Input.GetKeyDown(KeyCode.Space)&& (_groundcheck||waterCheck))   
             
        {
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, jumpforce);
        }

        if (_rigidbody2d.velocity.y < 0)
        {
            _rigidbody2d.velocity +=  gravityforce * (fallforce * Time.deltaTime);
        }
      

    }   
    
     
           
}

       
         
          
       
