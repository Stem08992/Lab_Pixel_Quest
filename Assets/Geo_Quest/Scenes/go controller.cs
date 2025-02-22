using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gocontroller : MonoBehaviour
{
    string String = "Hello";
    int var = 3;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        string StringW = "World";
        Debug.Log(String + StringW);
    } 
    // Update is called once per frame
    void Update()
    {
        Debug.Log(var);
        var++;
        
    }
}
