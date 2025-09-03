using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TalkController : MonoBehaviour
{
    /// <summary>
    /// This Script controls talking done in the dialogue portions  
    /// </summary>
    
    //========== Connections to Visuals 
    private AudioSource _audioSource;       //Plays the sound every time player hits space 
    private Canvas _dialogueCanvas;         //The canvas that holds all the images 
    private TextMeshProUGUI _dialogueText;  //The text box that displays the text 
    private Image _character;               //The sprite of the image of the character talking 
    
    //=========== Internal Vars 
    public string[] sentences;          //Holds all the sentences this talk space offers 
    public int index = 0;               //Tells us which sentence we're at 
    private bool _breakOut = false;     //Tells us if the conversation is over or not 
    private bool _isTalking = false;    //Tells us if we're still in conversation, in case you want to skip the dialogue 
    public float dialogueSpeed;         //Tells us how fast the speed of the letters appearing should be 

    //==================================================================================================================
    // Functions 
    //==================================================================================================================
    
    //Connects all the components 
    public void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _dialogueCanvas = GetComponent<Canvas>();
        _dialogueText = GameObject.Find($"Dialogue_Canvas").transform.Find($"TalkText").GetComponent<TextMeshProUGUI>();
        _character = GameObject.Find($"Dialogue_Canvas").transform.Find($"Panel").transform.Find($"Character").GetComponent<Image>();
    }
    
    //Allows player continue forward in the conversation 
    public void TalkUpdate()
    {
        if (!Input.GetButtonDown("Fire1")) return;
        PlayAudio();
        //If we reached the end exit out of the talking bit 
        if (Done())
        {
            SetCanvas(false);
            //GameObject.Find($"Main_Camera").GetComponent<GameFlow>().EndDialogue();
        }

        NextSentence();
    }

    //Plays the next sentence 
    private void PlayAudio()
    {
        _audioSource.Play();
    }
    
    //Loads in the new data from a Talk Zone and resets the index 
    public void LoadText(string[] newSentences, Sprite sprite)
    {
        index = 0;
        sentences = newSentences;
        _character.sprite = sprite;
    }

    //Tells us if we reached the end 
    private bool Done()
    {
        return index == sentences.Length;
    }

    //Sets the canvas to be on or off
    public void SetCanvas(bool state)
    {
        _dialogueCanvas.enabled = state;
    }
    

    //Checks if we can go to the next sentence if we can writes or if we're in the middle of the sentence we skip ahead
    public void NextSentence()
    {
        if (index <= sentences.Length - 1 && !_isTalking)
        {
            _dialogueText.text = "";
            _isTalking = true;
            StartCoroutine(WriteSentence());
        }
        else
        {
            _breakOut = true;
        }
    }

    //Parses through the sentences adding in one letter at a time and listens for if the player wants to move to next 
    //sentence 
    private IEnumerator WriteSentence()
    {
        //Goes through all the letters in the sentence 
        foreach (var dialogueTextText in sentences[index].ToCharArray())
        {
            //If the player actioned to move forward we stop writing this sentence and we move onto the next one 
            if (_breakOut)
            {
                //Clear our for next sentence 
                _breakOut = false;
                index++;
                _dialogueText.text = "";
                //Check if we this would be the end or we can do the next sentence 
                if (index >= sentences.Length)
                {
                    SetCanvas(false);
                    //GameObject.Find($"Main_Camera").GetComponent<GameFlow>().EndDialogue();
                    _isTalking = false;
                    yield break;
                }
                //Start the next sentence 
                StartCoroutine(WriteSentence());
                yield break;
            }
            //Adds the letter 
            _dialogueText.text += dialogueTextText;
            yield return new WaitForSeconds(dialogueSpeed);
        }
        //Once we finished all the letter stop adding letters and move forward 
        _isTalking = false;
        index++;
    }
}
