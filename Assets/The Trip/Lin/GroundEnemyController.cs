using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundEnemyController : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int patrolIndex = 0;
    public float speed = 5;
    public float watTime = 1;
    private float currentTime = 1;

    void Start()
    {
        transform.position = patrolPoints[patrolIndex].position;
        currentTime = watTime;
    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[patrolIndex].position, speed * Time.deltaTime);

        if (transform.position == patrolPoints[patrolIndex].position)
        {
            patrolIndex++; 
            if (patrolIndex >= patrolPoints.Length)
            {
                patrolIndex = 0;
                currentTime = watTime;
            }
        }
        else
        {
            currentTime -= Time.deltaTime;
        }

    }   
}