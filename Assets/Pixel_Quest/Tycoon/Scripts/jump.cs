using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public float capsuleh = .25f;
    public float capsuler = .08f;
    public float fallforce = 2;
    private bool watercheck;
    private string watertag = "Water";
    private Vector2 gravityvec;
    public Transform feetcoll;
    public LayerMask groundmask;
    private bool groundcheck;   
    public float jumpforce = 10;
    private Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag(watertag)) { watercheck = true; }}
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(watertag)) { watercheck = false; }
    }
    // Start is called before the first frame update
    void Start()
    {
        gravityvec= new Vector2(0,Physics.gravity.y);  
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        groundcheck = Physics2D.OverlapCapsule(feetcoll.position, new Vector2(capsuleh, capsuler), CapsuleDirection2D.Horizontal, 0, groundmask);
        if (Input.GetKeyDown(KeyCode.Space)&&(groundcheck||watercheck))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
        if (rb.velocity.y < 0 && watercheck)
        {
            rb.velocity += gravityvec * (fallforce * Time.deltaTime);
        }
    }
}
