using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FPNPC : MonoBehaviour
{

    public List<string> dialogue = new List<string>();
    public List<string> names = new List<string>();
    public List<Sprite> spriteList = new List<Sprite>();
    public string nextScene = "";

    private FPOrderData order;
    public FPDialogue fPDialogue;

    public GameObject mouseSprite;
    //private GameObject _talkIcon;

    private void Update()
    {
        GameObject orderObj = GameObject.FindGameObjectWithTag("OrderData");
        if (orderObj != null)
        {
            order = orderObj.GetComponent<FPOrderData>();
        }
            //_talkIcon = transform.Find(FPStructs.GameObjects.talkIcon).gameObject;
            //_talkIcon.SetActive(false);
        }

    private void OnMouseDown()
    {
        mouseSprite.SetActive(false);

        fPDialogue.CopyDialogue(dialogue, names, nextScene, spriteList);
        fPDialogue.SetCanSpeak(true);

        Debug.Log(order.orderPlaced);
        if (order.orderPlaced == true)
        {
            if (order.score == order.maxScore)
            {
                fPDialogue.dialogue.Insert(0, "Perfect score, thank you!");
            }
            else if (order.score == 0)
            {
                fPDialogue.dialogue.Insert(0, "Not your best work..");
            }
            else if (order.score == 1)
            {
                fPDialogue.dialogue.Insert(0, "Decent but could have done better!");
            }

        }

        // randomize order
        if (order.orderPlaced == false)
        {
            order.requiredCoffeeSoda = Random.Range(0, 3);
            order.requiredIce = Random.Range(0, 3);

            string IceDialogue = "";
            string CoffeeSodaDialouge = "";

            if (order.requiredIce == 0)
            {
                IceDialogue = "I'd perfer my drink on the warmer side";
            }
            else if (order.requiredIce == 1)
            {
                IceDialogue = "I'd perfer my drink on the coolor side";
            }
            else
            {
                IceDialogue = "I'd perfer my drink really cold";
            }

            if (order.requiredCoffeeSoda == 0)
            {
                CoffeeSodaDialouge = "Just coffee will do";
            }
            else if (order.requiredCoffeeSoda == 1)
            {
                CoffeeSodaDialouge = "I want a mix of coffee and Soda please, any ratio will do";
            }
            else if (order.requiredCoffeeSoda == 2)
            {
                CoffeeSodaDialouge = "Just soda will do";
            }


            fPDialogue.dialogue.Add(CoffeeSodaDialouge + " and " + IceDialogue);
        }

    }
}
