using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoController : MonoBehaviour
{
    private int varone = 1;

    public GeoController(int varone)
    {
        this.varone = varone;
    }

    private string stone = "How are you";
    int varTwo = 3;

    public override bool Equals(object obj)
    {
        return obj is GeoController controller &&
               base.Equals(obj) &&
               varone == controller.varone;
    }

    // Start is called before the first frame update    
    void Start()
    {
        Debug.Log("Hello World,my name is stone");
        Debug.Log("I think that the class I am learing is intersting");
        string stan = "I'm fine,thank you and you?";
        Debug.Log(stone+"   "+stan);
        Debug.Log(transform.position+=new Vector3(0.005f,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(varTwo);
        varTwo++;
        
    }
}
