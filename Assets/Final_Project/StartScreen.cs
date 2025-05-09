using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour

{
    private float timer = 1;
    private const float resetTime = 1;


    bool isTimerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()


    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("testtrue");
        }
        if (Input.GetKeyDown(KeyCode.Q) && !isTimerOn)
        {
            isTimerOn = true;
            timer = resetTime;
            Debug.Log("start");
        }

        if (isTimerOn)
        {
            timer -= Time.deltaTime;
            Debug.Log("counting");
        }

        if (timer <= 0 && isTimerOn)
        {
            isTimerOn= false;
            Debug.Log("end");
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        {
            //SceneManager.LoadScene(finalScene);
        }

    }
}
