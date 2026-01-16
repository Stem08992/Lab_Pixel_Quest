using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnKeyPress : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Colors to switch between
    public Color color1 = Color.red;
    public Color color2 = Color.green;
    public Color color3 = Color.blue;

    void Start()
    {
        // Get the SpriteRenderer component of the object
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Change color when keys 1, 2, or 3 are pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spriteRenderer.color = color1; // Change to red
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spriteRenderer.color = color2; // Change to green
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spriteRenderer.color = color3; // Change to blue
        }
    }
}
