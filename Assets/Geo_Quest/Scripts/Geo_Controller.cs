using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.SceneManagement;

public class Geo_Controller : MonoBehaviour {
    int variable1 = 2;
    private string Var2 = "Good Morning ";
    int Var3 = 3;

    private Rigidbody2D rb2d;
    private SpriteRenderer _spriteRenderer;
    public int speed = 5;

    // Start is called before the first frame update
    public void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        
        //string Var1 = "World";
        //Debug.Log(Var2 + Var1);
    }
    
    // Update is called once per frame
     void Update() {
        float xInput = Input.GetAxis("Horizontal");
        xInput *= variable1;

        if (xInput > 0) { _spriteRenderer.flipX = true; }
        else if (xInput < 0) { _spriteRenderer.flipX = false; }

        rb2d.velocity = new Vector2(xInput * speed, rb2d.velocity.y);


        }

    public string nextLevel = "Level2";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        switch (collision.tag)
        {
            case "Death":{
                    string thisLevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisLevel);
                    break;
                }
            case "Finish":{
                    SceneManager.LoadScene(nextLevel);                    
                    break;
                }
        }
    }

}
