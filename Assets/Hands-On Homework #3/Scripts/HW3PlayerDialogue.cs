using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HW3PlayerDialogue : MonoBehaviour
{
    public List<string> dialogue = new List<string>();
    public List<string> names= new List<string>();
    private bool canSpeak = false;
    private bool isSpeaking = false;
    private GameObject _talkPanel;
    private TextMeshProUGUI _talkText;
    public TextMeshProUGUI nameText;
    private int _talkIndex = 0;

    private void Start()
    {
        _talkText = GameObject.Find(HW3Structs.GameObjects.talkText).GetComponent<TextMeshProUGUI>();

        _talkPanel = GameObject.Find(HW3Structs.GameObjects.talkPanel);
        _talkPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpeaking && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogue.Count - 1 == _talkIndex)
            {
                isSpeaking = false;
                _talkPanel.SetActive(false);
            }
            else
            {
                _talkIndex++;
                nameText.text = names[_talkIndex];
                _talkText.text = dialogue[_talkIndex];
            }
        }
        else if (canSpeak && Input.GetKeyDown(KeyCode.E))
        {
            isSpeaking = true;
            _talkPanel.SetActive(true);
            _talkIndex = 0;
            nameText.text = names[_talkIndex];
            _talkText.text = dialogue[_talkIndex]; 
        }
    }

    public void SetCanSpeak(bool newCanSpeak)
    {
        canSpeak = newCanSpeak;
    }

    public bool IsSpeaking()
    {
        return isSpeaking;
    }

    public void CopyDialogue(List<string> newDialogue, List<string> newNames)
    {
        dialogue.Clear();
        dialogue.AddRange(newDialogue);

        names.Clear();
        names.AddRange(newNames);
    }
}
