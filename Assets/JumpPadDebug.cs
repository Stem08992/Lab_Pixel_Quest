using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadDebug : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Object entering trigger: " + collision.gameObject.name);

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy has touched the jump pad!");
        }
    }
}
