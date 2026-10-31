using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoController : MonoBehaviour {
    // Start is called before the first frame update
    private int _varibleOne = 5;
    public int varibleTwo = 255;
    
    private void Start() {
        int varTwo = 2;
        _varibleOne = 2; 
        Debug.Log("Start");
    }

    // Update is called once per frame
    private void Update() {
        _varibleOne = 5;
        Debug.Log(transform.position);
    }
}
