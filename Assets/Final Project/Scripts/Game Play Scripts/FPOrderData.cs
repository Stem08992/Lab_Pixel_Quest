using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPOrderData : MonoBehaviour
{
    public int requiredCoffeeSoda;
    public int requiredIce;

    public int score = 0;
    public int maxScore = 2;

    public bool orderPlaced = false;

    private Transform Player;

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Player = player.transform;
        }

    }
    void Awake()
    {

        GameObject[] all = GameObject.FindGameObjectsWithTag("OrderData");

        if (all.Length > 1)
        {
            Destroy(gameObject); 
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void CheckScore()
    {


        FPCupStats stats = Player.GetChild(0).GetComponent<FPCupStats>();
        score = 0;

        if (requiredIce == stats.ice)
        {
            score++;
        }
        if (requiredCoffeeSoda == 0 && stats.coffee == 4)
        {
            score++;
        }
        else if (requiredCoffeeSoda == 1 && stats.soda > 0 && stats.coffee > 0 && stats.totalIngredients == 4)
        {
            score++;
        }
        else if (requiredCoffeeSoda == 2 && stats.soda == 4)
        {
            score++;
        }

    }

}

