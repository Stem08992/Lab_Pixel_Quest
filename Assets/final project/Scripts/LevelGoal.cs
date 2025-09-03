using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public string nextLevel = "L2";
    public string thirdLevel = "L3";
    public string EndPage = "EndScene";



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }





    private void OnTriggerEnter2D(Collider2D other)
    {


        switch (other.tag)
        {
            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
            case "LVL2FINISH":
                {
                    SceneManager.LoadScene(thirdLevel);
                    break;
                }
            case "The End":
                {
                    SceneManager.LoadScene(EndPage);
                    break;
                }

        }
    }
}
