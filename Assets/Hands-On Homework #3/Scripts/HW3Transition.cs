using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HW3Transition : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Finish":
                {
                    string nextLevel = collision.GetComponent<HW3LevelGoal>().nextLevel;
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
        }
    }

        }
