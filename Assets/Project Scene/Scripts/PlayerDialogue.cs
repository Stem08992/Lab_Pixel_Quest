using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
    public List<string> dialogue = new List<string>();
    private bool canSpeak = false;
    private bool isSpeaking = false;
    private GameObject _talkPanel;
    private TextMeshProUGUI _talkText;
    private int _talkIndex = 0;

   private void Start()
{
    // Find the text component
    GameObject textObj = GameObject.Find(ProjectStructs.GameObjects.talkText);
    if (textObj != null) 
    {
        _talkText = textObj.GetComponent<TextMeshProUGUI>();
    }

    // Find the panel
    _talkPanel = GameObject.Find(ProjectStructs.GameObjects.talkPanel);
    
    // Only try to deactivate if we actually found it
    if (_talkPanel != null)
    {
        _talkPanel.SetActive(false);
    }
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
                _talkText.text = dialogue[_talkIndex];
            }
        }
        else if (canSpeak && Input.GetKeyDown(KeyCode.E))
        {
            isSpeaking = true;
            _talkPanel.SetActive(true);
            _talkIndex = 0;
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

    public void CopyDialogue(List<string> newDialogue)
    {
        dialogue.Clear();
        dialogue.AddRange(newDialogue);
    }
}
