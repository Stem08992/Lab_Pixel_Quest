using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public List<string> dialogue = new List<string>();
    private GameObject _talkIcon;

    private void Start()
    {
        _talkIcon = transform.Find(Structs.GameObjects.talkIcon).gameObject;
        _talkIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Structs.Tags.playerTag)
        {
            _talkIcon.SetActive(true);
            collision.GetComponent<PlayerDialogue>().CopyDialogue(dialogue);
            collision.GetComponent<PlayerDialogue>().SetCanSpeak(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Structs.Tags.playerTag)
        {
            _talkIcon.SetActive(false);
            collision.GetComponent<PlayerDialogue>().SetCanSpeak(false);
        }
    }

}
