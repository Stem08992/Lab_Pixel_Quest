using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntegerTest : MonoBehaviour
{

    string variable1 = "Hello";

    private int var1 = 3;


    // Start is called before the first frame update
    void Start()
    {

        string variable2 = " World";
            Debug.Log(variable1 + variable2);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(var1++);
    }
}
