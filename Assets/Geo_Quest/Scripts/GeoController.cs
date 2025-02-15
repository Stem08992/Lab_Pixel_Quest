using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world");

        int x = 1;
        int z = 3;
        Debug.Log(z);
        z++;

        if (x == 1){
            Debug.Log(z+1);
        }
        z++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
