using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TrainMovement : MonoBehaviour
{
    public float moveDistance = 10f; // How far to move back and forth
    public float speed = 2f;         // How fast the train moves

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // PingPong returns a value between 0 and moveDistance
        float offset = Mathf.PingPong(Time.time * speed, moveDistance);
        transform.position = startPos + transform.right * offset;
    }
}
