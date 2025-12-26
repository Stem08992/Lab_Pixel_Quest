using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPAddIngredients : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    private void OnMouseDown()
    {
        string tag = gameObject.tag;
        Transform cup = Player.transform.GetChild(0);
        FPCupStats stats =  cup.GetComponent<FPCupStats>();

        if (stats.totalIngredients < 4)
        {
            switch (tag)
            {
                case "Ice":
                    {
                        stats.ice += 1;
                        stats.totalIngredients += 1;
                        break;
                    }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
