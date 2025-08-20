using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Camera offset
    void Start()
    {
        
    }
    void Update()
    {
        // Camera follows the player with an offset
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
    }
}

    // Start is called before the first frame update
    

    

