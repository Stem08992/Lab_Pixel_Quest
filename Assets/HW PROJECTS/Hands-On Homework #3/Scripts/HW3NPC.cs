using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HW3NPC : MonoBehaviour
{
    public List<string> dialogue = new List<string>();
    private GameObject _talkIcon;

    private void Start()
    {
        _talkIcon = transform.Find(HW3Structs.GameObjects.talkIcon).gameObject;
        _talkIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == HW3Structs.Tags.playerTag)
        {
            _talkIcon.SetActive(true);
            collision.GetComponent<HW3PlayerDialogue>().CopyDialogue(dialogue);
            collision.GetComponent<HW3PlayerDialogue>().SetCanSpeak(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == HW3Structs.Tags.playerTag)
        {
            _talkIcon.SetActive(false);
            collision.GetComponent<HW3PlayerDialogue>().SetCanSpeak(false);
        }
    }

}
