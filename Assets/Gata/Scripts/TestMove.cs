using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TestMove : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Rotate()
    {
        //Quaternion rot = Quaternion.LookRotation(target.transform.position)
        //Vector3 fixedRot = new Vector3(0,0,rot.z);
        //print(fixedRot);
        transform.right = target.transform.position - transform.position;
    }

    private void move()
    {
        float speed = 1f;
        rb.velocity = Vector3.MoveTowards(transform.position, target.transform.position, speed*Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Rotate();
            move();
        }
        
    }
}
