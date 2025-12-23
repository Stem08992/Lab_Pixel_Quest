using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DestroyTimer : MonoBehaviour {
    void Start() { Destroy(gameObject, 0.15f); } // Adjust time to match animation length
}
