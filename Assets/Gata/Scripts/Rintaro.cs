using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Rintaro : MonoBehaviour
{
    private Character Rin;
    // Start is called before the first frame update
    void Start()
    {
        Rin = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        Rin.charachterMove();
        if (Rin.health <= 0)
        {
            string thisLevel = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(thisLevel);
        }

        for (int i = 0; i < Rin._moveList.Length; i++)
        {
            Rin.canShootFunc(i);
            Rin.shootFunc(i, Rin.getMove(i)._key);
            //print("hi");
        }
    }
}
