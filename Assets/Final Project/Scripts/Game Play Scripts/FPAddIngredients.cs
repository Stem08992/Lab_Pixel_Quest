using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPAddIngredients : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public Transform MinigamePanel;

    public float updateDuration = 1f;
    private int maxIngredients = 4;
 
    private void OnMouseDown()
    {
        string tag = gameObject.tag;
        FPHoldBarMinigame minigame = MinigamePanel.GetComponent<FPHoldBarMinigame>();

        if (Player.transform.childCount >= 1)
        {
            FPCupStats stats = Player.transform.GetChild(0).GetComponent<FPCupStats>();

            switch (tag)
            {
                case "Ice":
                    {
                        if (stats.ice < 2)
                        {
                            stats.ice += 1;

                        }
                        break;
                    }
                case "Coffee":
                    {
                        if (stats.totalIngredients < maxIngredients)
                        {
                            if (minigame.ingredientStat > maxIngredients - stats.totalIngredients)
                            {
                                stats.coffee += maxIngredients - stats.totalIngredients;
                                stats.totalIngredients += maxIngredients - stats.totalIngredients;
                            }
                            else
                            {
                                stats.coffee += minigame.ingredientStat;
                                stats.totalIngredients += minigame.ingredientStat;
                            }
                        }
                        break;
                    }

                case "Soda":
                    {
                        if (stats.totalIngredients < maxIngredients)
                        {
                            if (minigame.ingredientStat > maxIngredients - stats.totalIngredients)
                            {
                                stats.soda += maxIngredients - stats.totalIngredients;
                                stats.totalIngredients += maxIngredients - stats.totalIngredients;
                            }
                            else
                            {
                                stats.soda += minigame.ingredientStat;
                                stats.totalIngredients += minigame.ingredientStat;
                            }
                        }
                        break;
                    }
            }
        }
    }

}

