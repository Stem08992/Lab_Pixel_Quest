using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    public List<string> dialogue = new List<string>();
    private TextMeshProUGUI _talkText;
    private int _talkIndex = 0;
    private RectTransform rt;
    public string nextLevel = "Ocean 1";


    //Tranfrom or
    //Tranfom new

    // Start is called before the first frame update
    void Start()
    {
        _talkText = GameObject.Find(Structs.GameObjects.talkText).GetComponent<TextMeshProUGUI>();

        _talkText.text = dialogue[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogue.Count - 1 == _talkIndex)
            {

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(nextLevel);
                }

            }
            else
            {
                if (_talkIndex == 2)
                {
                    transform.localScale = new Vector3(0.75f, 0.5f, 0.5f);
                    GetComponent<RectTransform>().anchoredPosition = new Vector2(-0, 150);

                }
                //If index == 4
                // tansfomr.postion = new.postion;
                _talkIndex++;
                _talkText.text = dialogue[_talkIndex];
            }
        }

    }
}
