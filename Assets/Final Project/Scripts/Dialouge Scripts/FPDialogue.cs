using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPDialogue : MonoBehaviour
{
    public List<string> dialogue = new List<string>();
    public List<string> names= new List<string>();
    public string nextScene = "";
    private bool canSpeak = false;
    private bool isSpeaking = false;
    private GameObject _talkPanel;
    private TextMeshProUGUI _talkText;
    public TextMeshProUGUI nameText;
    private int _talkIndex = 0;
    public GameObject order; 
        
    private void Start()
    {
        _talkText = GameObject.Find(FPStructs.GameObjects.talkText).GetComponent<TextMeshProUGUI>();

        _talkPanel = GameObject.Find(FPStructs.GameObjects.talkPanel);
        _talkPanel.SetActive(false);
        SetCanSpeak(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (isSpeaking && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogue.Count - 1 <= _talkIndex)
            {
                isSpeaking = false;
                _talkPanel.SetActive(false);
                StartCoroutine(LoadScene());    

            }
            else
            {
                _talkIndex++;
                nameText.text = names[_talkIndex];
                _talkText.text = dialogue[_talkIndex];
            }
        }
        else if (canSpeak && !isSpeaking)
        {
            isSpeaking = true;
            canSpeak = false;
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

    public void CopyDialogue(List<string> newDialogue, List<string> newNames, string newScene)
    {
        dialogue.Clear();
        dialogue.AddRange(newDialogue);

        names.Clear();
        names.AddRange(newNames);
        nextScene = newScene;
    }


    private IEnumerator LoadScene()
    {
        order.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextScene);
    }
}
