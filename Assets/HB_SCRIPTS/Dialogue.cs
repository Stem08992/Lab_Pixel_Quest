using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public string[] DialogueArray;
    public bool[] isItalicArray;
    public int DialogueIndex = 0;
    private TextMeshProUGUI _TextMeshPro;
    public Color[] textColor;
    private bool isTyping = false;
    public float amountTime;

    [Header("Scene Transition")]
    public string nextSceneName; // Set this in the Inspector

    void Start()
    {
        _TextMeshPro = GameObject.Find("Dialogue").GetComponent<TextMeshProUGUI>();

        if (DialogueArray.Length == 0)
        {
            Debug.LogWarning("DialogueArray is empty!");
            return;
        }

        if (isItalicArray.Length != DialogueArray.Length)
        {
            Debug.LogWarning("isItalicArray length doesn't match DialogueArray length!");
            return;
        }

        if (textColor.Length < DialogueArray.Length)
        {
            Debug.LogWarning("textColor array should be at least as long as DialogueArray!");
        }

        StartCoroutine(DisplayDialogue());
    }

    IEnumerator DisplayDialogue()
    {
        isTyping = true;

        if (DialogueIndex < DialogueArray.Length && DialogueIndex < textColor.Length)
        {
            _TextMeshPro.text = "";
            _TextMeshPro.color = textColor[DialogueIndex];

            string currentText = DialogueArray[DialogueIndex];
            bool italicThis = isItalicArray[DialogueIndex];

            string displayText = italicThis ? "<i>" + currentText + "</i>" : currentText;

            for (int i = 0; i < displayText.Length; i++)
            {
                _TextMeshPro.text += displayText[i];
                yield return new WaitForSeconds(amountTime);
            }
        }
        else
        {
            Debug.LogWarning("DialogueIndex or textColor array is out of bounds!");
        }

        isTyping = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isTyping)
        {
            DialogueIndex++;

            // Finished all lines
            if (DialogueIndex >= DialogueArray.Length)
            {
                if (!string.IsNullOrEmpty(nextSceneName))
                {
                    SceneChanger.Instance.ChangeScene(nextSceneName);
                    enabled = false; // prevent further input
                }
                else
                {
                    Debug.Log("Dialogue finished. No nextSceneName specified.");
                }
                return;
            }

            StartCoroutine(DisplayDialogue());
        }
    }
}
