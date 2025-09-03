using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class Geocontroller : MonoBehaviour
{
    string variable1 = "hello";
    int var1 = 3;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    
        int speed = 10;

    

    public string thirdlevel = "S3";
    public string nextlevel = "Geo_Quest_Scene_1 1";
    // Start is called before the first frame update
    void Start()
    {
          sr = GetComponent<SpriteRenderer>();
        
        
        
        rb = GetComponent<Rigidbody2D>();
        
        string var2 = "hi how are you today";
       // Debug.Log("Hello world");
        Debug.Log(variable1 + var2);


    }

    // Update is called once per frame
    void Update()

    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sr.color = new Color(1, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sr.color = new Color(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sr.color = new Color(0, 0, 1);
        }


        float xInput = Input.GetAxis("Horizontal");
        // Debug.Log(xInput);


        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

    } 

       //{ if (Input.GetKeyDown(KeyCode.A)) { transform.position = new Vector3(-1, 0, 0); } } 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    string thislevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thislevel);

                    break;



                  
                }

            case "Finish":
                {
                    SceneManager.LoadScene(nextlevel);
                    break;
                }

            case "thirdLevel":
               SceneManager.LoadScene(thirdlevel);
                break;

   





        }  
        
               
           
        

        
         
        
    }


  
}     
    
         
        
      
 
        






        






    




