using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMen : MonoBehaviour
{
    // Start is called before the first frame update

    public void goToTutorial()
    {
        SceneManager.LoadScene("LucyTutorial");
    }
    void Start()
    {

    }

    // Update is called once per frame
    //void Update()
    //{

    //}
}