using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationTest : MonoBehaviour
{
    // Start is called before the first frame update
    Quaternion change = Quaternion.Euler(1000, 1000, 1000);
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, .02f, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -.02f, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-.02f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(.02f, 0, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.rotation = Quaternion.Slerp(Quaternion.identity, change, .1f);
        }
    }
}
