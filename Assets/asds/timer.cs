using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    

public class SimpleTimer : MonoBehaviour
{
    public float timer = 10f; // Start at 10 seconds

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            Debug.Log("Timer: " + Mathf.Ceil(timer)); // Print timer in console
        }
        else
        {
            Debug.Log("Time's up!");
        }
    }
}
