using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoController : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 3;
    public string nextLevel;

    public SpriteRenderer spriteRenderer;

    public Color color1;
    public Color color2;
    public Color color3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
        changeColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
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

    public void changeColor()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            spriteRenderer.color = color1;
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha2)){
            spriteRenderer.color = color2;
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha3)){
            spriteRenderer.color = color3;
        }
    }
}
