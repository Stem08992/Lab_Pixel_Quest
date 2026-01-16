using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    TextAsset DialogueIntro;
    string dialogue;
    List<string> dialogueLines = new List<string>();
    public List<DialogueOption> dialogueOptions = new List<DialogueOption>();
    private int currentIndex = 0; //Conversation number
    private int choiceNum = 0;
    private bool choiceState = false;
    private bool buttonsActive = false;
    public TextMeshProUGUI dialogueText;
    public GameObject Buttons;
    public List <TextMeshProUGUI> choiceTexts;
    public string nextLevel = "fight";
    private void Start()
    {
        currentIndex = 0;
        DialogueIntro = Resources.Load<TextAsset>("Dialogues/DialogueIntro");
        dialogue = DialogueIntro.text;
        dialogueLines = dialogue.Split(new[] { '\n' }).ToList();
        foreach (string line in dialogueLines) //Loads and trims all dialogue types
        {
            dialogueOptions.Add(new DialogueOption());
            if (line.Contains("+"))
            {
                dialogueOptions[currentIndex].TextPlus.Add(line.Replace("+", "").Trim()); //Normal text
            }
            else if (line.Contains("~"))
            {
                dialogueOptions[currentIndex].TextTilde.Add(line.Replace("~", "").Trim()); //Option prompts
            }
            else if (line.Contains("|"))
            {
                dialogueOptions[currentIndex].optionText.Add(line.Replace("|", "").Trim()); //Options
            }

            else if (line.Contains("/"))
            {
                dialogueOptions[currentIndex].responseLines.Add(line.Replace("/", "").Trim()); //Responses

            }
            else if (line.Contains("(")) //End index
            {
                currentIndex++;
            }

        }

        currentIndex = 0; //Initialize index

        foreach (string option in dialogueOptions[currentIndex].optionText)
        {
            //Debug.Log(option);
        }

        UISetup(); //Initialize UI and buttons
        
    }

    //STATES: BUTTON + PROMPT TEXT (choiceState = true), NORMAL TEXT (choiceState = false), RESPONSE TEXT (choiceState = true)

    public void Update()
    {
    //Press E, if you're in a response text, go to next index
    //Otherwise, if you're in normal text, go to option choices (needs to be fixed, we need the ability to do consecutive normal text)

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(!buttonsActive && choiceState)
            {
                currentIndex++;
                buttonsActive = false;
                choiceState = false;
            }
            else if(!buttonsActive && !choiceState)
            {
                buttonsActive = true;
                choiceState = true;
            }

            UISetup();
            //Debug.Log(choiceState);
            //Debug.Log(buttonsActive);

        }
    }
    public void buttonClicked(int optionNum) //When a button is clicked, set the response text
    {
        Buttons.SetActive(false);
        buttonsActive = false;
        choiceNum = optionNum;
        dialogueText.text = dialogueOptions[currentIndex].responseLines[optionNum];
        print(dialogueText.text);
        if(dialogueText.text.Contains("Yay! Let"))
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
    public void UISetup()
    {
        Buttons.SetActive(buttonsActive);
        if (dialogueOptions[currentIndex].optionText.Count >= 1) //Set buttons to active or inactive, go through options and set choice options
        {
            for (int i = 0; i < dialogueOptions[currentIndex].optionText.Count; i++)
            {
                choiceTexts[i].text = dialogueOptions[currentIndex].optionText[i];
            }


            if (buttonsActive == false && choiceState == false) //If in a normal text state, load normal text
            {
                dialogueText.text = dialogueOptions[currentIndex].TextPlus[0];
            }
            else if (buttonsActive && choiceState) // If in a button state, load option prompts
            { 
                dialogueText.text = dialogueOptions[currentIndex].TextTilde[0];
            }
        }
    }
}

[Serializable]
public class DialogueOption
{
    public List<string> TextTilde = new List<string>();
    public List<string> TextPlus = new List<string>();
    public List<string> optionText = new List<string>();
    public List<string> responseLines = new List<string>();

}


