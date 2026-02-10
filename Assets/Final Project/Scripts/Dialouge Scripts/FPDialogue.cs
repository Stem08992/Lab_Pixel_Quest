using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPDialogue : MonoBehaviour
{
    public List<string> dialogue = new List<string>();
    public List<string> names= new List<string>();
    public List<Sprite> spriteList = new List<Sprite>();
    public string nextScene = "";

    private bool canSpeak = false;
    private bool isSpeaking = false;

    private GameObject _talkPanel;
    private TextMeshProUGUI _talkText;
    public TextMeshProUGUI nameText;
    private int _talkIndex = 0;
    public GameObject order;
    public GameObject npc;
    private SpriteRenderer npcSprite;
    private FPOrderData orderData;

    private void Start()
    {
        _talkText = GameObject.Find(FPStructs.GameObjects.talkText).GetComponent<TextMeshProUGUI>();

        _talkPanel = GameObject.Find(FPStructs.GameObjects.talkPanel);
        _talkPanel.SetActive(false);
        SetCanSpeak(false);

        npcSprite = npc.transform.GetChild(0).GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        GameObject orderObj = GameObject.FindGameObjectWithTag("OrderData");
        if (orderObj != null)
        {
            orderData = orderObj.GetComponent<FPOrderData>();
        }

        if (isSpeaking && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogue.Count - 1 <= _talkIndex)
            {
                isSpeaking = false;
                _talkPanel.SetActive(false);
                orderData.orderPlaced = !orderData.orderPlaced;
                SceneManager.LoadScene(nextScene);
                //StartCoroutine(LoadScene());    

            }
            else if (dialogue.Count - 2 == _talkIndex)
            {
                if(orderData.orderPlaced == false) { _talkText.color = new Color(37, 217, 223, 255); }
                _talkIndex++;
                nameText.text = names[_talkIndex];
                _talkText.text = dialogue[_talkIndex];
                npcSprite.sprite = spriteList[_talkIndex];
            }
            else
            {
                _talkIndex++;
                nameText.text = names[_talkIndex];
                _talkText.text = dialogue[_talkIndex];
                npcSprite.sprite = spriteList[_talkIndex];
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
            npcSprite.sprite = spriteList[_talkIndex];
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

    public void CopyDialogue(List<string> newDialogue, List<string> newNames, string newScene, List<Sprite> newSprite)
    {
        dialogue.Clear();
        dialogue.AddRange(newDialogue);

        names.Clear();
        names.AddRange(newNames);

        spriteList.Clear();
        spriteList.AddRange(newSprite);

        nextScene = newScene;
    }


    private IEnumerator LoadScene()
    {
        order.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextScene);
    }
}
