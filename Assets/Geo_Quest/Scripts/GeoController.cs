using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoController : MonoBehaviour
{
    public class GeoScript : MonoBehaviour
    {
        string String = "Hello ";
        int burger = 3;
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Hello world");

            int x = 1;
            int z = 3;
            Debug.Log(z);
            z++;

            if (x == 1)
            {
                Debug.Log(z + 1);
            }
            z++;
        }
    }

}
