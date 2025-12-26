using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FPNPC : MonoBehaviour
{

    public List<string> dialogue = new List<string>();
    public List<string> names = new List<string>();
    public string nextScene = "";
    public FPDialogue fPDialogue;
    //private GameObject _talkIcon;

    private void Start()
    {
        //_talkIcon = transform.Find(FPStructs.GameObjects.talkIcon).gameObject;
        //_talkIcon.SetActive(false);
    }

    private void OnMouseDown()
    {
        fPDialogue.CopyDialogue(dialogue, names, nextScene);
        fPDialogue.SetCanSpeak(true);

    }
}
