using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCupPickup : MonoBehaviour
{
    public GameObject currentCup;
    public GameObject cupPrefab;
    public Transform Player;
    public Transform CoffeeArea;
    public Transform SodaArea;


    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if (Player.transform.childCount < 1 && CoffeeArea.transform.childCount < 1 && SodaArea.transform.childCount < 1)
        {
           currentCup = Instantiate(cupPrefab, Player.position, Quaternion.identity);
           currentCup.transform.SetParent(Player);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
