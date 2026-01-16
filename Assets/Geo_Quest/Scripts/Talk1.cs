using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Talk1 : MonoBehaviour
{
    public string nextLevel = "Scene_2";
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        switch (collision.tag)
        {
            case "Win":
                {
                    break;
                }
            case "Death": 
                {
                    string thisLevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisLevel); 
                    break;
                }
            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
        
        }
    }
        
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
