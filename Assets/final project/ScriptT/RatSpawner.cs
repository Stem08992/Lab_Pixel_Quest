using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawner : MonoBehaviour { 

    public GameObject ratPrefab;
    public Transform spawnPoint;

    void Start()
    {
        int chance = Random.Range(1, 6); // 1 to 5
        if (chance == 1) // 20% chance
        {
            SpawnRat();
        }
    }

    void SpawnRat()
    {
        Instantiate(ratPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("Rat spawned!");
    }
}