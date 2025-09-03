using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Build;

public class Talkingscripts : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    [TextArea(3, 10)] public List<string> dialogueLines;
    public float typingSpeed = 0.05f;

    public AudioSource typingAudio; // 🔊 New: Assign an AudioSource with typing sound

    private int currentLineIndex = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;
    public GameObject EnterKey;

    public List<GameObject> Options;

    void Start()
    {
        AddScoreBasedDialogue();
        StartTypingCurrentLine();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Enter key
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                textComponent.text = dialogueLines[currentLineIndex];
                isTyping = false;
                StopTypingSound(); // 🔇 Stop sound immediately
            }
            else
            {
                currentLineIndex++;
                if (Options.Count > 0)
                {
                    if (Options[currentLineIndex] != null)
                    {
                        Options[currentLineIndex].SetActive(true);
                        EnterKey.SetActive(false);
                    }

                }
                if (currentLineIndex < dialogueLines.Count)
                {
                    StartTypingCurrentLine();
                }
                else
                {
                    StartCoroutine(LoadNextSceneAfterDelay(1f));
                }
            }
        }
    }

    void AddScoreBasedDialogue()
    {
        if (GameManager.Instance != null)
        {
            string feedback = GameManager.Instance.GetScoreFeedback();

            string barSummary = $"📊 Status Report:\n" +
                                $"Happiness: {(int)(GameManager.Instance.popularity)}\n" +
                                $"Traffic: {(int)(GameManager.Instance.traffic)}\n" +
                                $"Pollution: {(int)(GameManager.Instance.pollution)} \n" +
                                $"Revenue: {(int)(GameManager.Instance.revenue)} \n";

            dialogueLines.Insert(0, feedback);
            dialogueLines.Insert(1, barSummary);
        }
    }

    void StartTypingCurrentLine()
    {
        typingCoroutine = StartCoroutine(TypeLine(dialogueLines[currentLineIndex]));
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        textComponent.text = "";

        PlayTypingSound(); // 🔊 Start sound

        foreach (char c in line)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        StopTypingSound(); // 🔇 Stop sound

        isTyping = false;
    }

    void PlayTypingSound()
    {
        if (typingAudio != null && !typingAudio.isPlaying)
        {
            typingAudio.Play();
        }
    }

    void StopTypingSound()
    {
        if (typingAudio != null && typingAudio.isPlaying)
        {
            typingAudio.Stop();
        }
    }

    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}