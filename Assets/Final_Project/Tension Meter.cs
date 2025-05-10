using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TensionMeter : MonoBehaviour
{
    public GameObject tensionBar;
    public GameObject castingMeter;
    public GameObject castingbar;
    public GameObject WholeTmeter;
    public SpriteRenderer qtepic; 
    public Sprite keyw;        
    public Sprite keya;        
    public Sprite keys;        
    public Sprite keyd;        

    public float minT = 3f;
    public float MaxT = 7f;
    public float mTV = 10f;
    public float speedup = 0.5f;
    public float speeddown = 1f;
    public float qteDuration = 50f;  

    private float cTension = 0f;
    private bool isTensionIncreasing = true;
    private bool isQTE = false;
    private bool isLineBroken = false;
    private float qteTimer;
    private int qteCount = 0;
    private int qtedone = 0;
    private string key;

    private void Start()
    {
        WholeTmeter.SetActive(false);
        Debug.Log("starting qtecount = " + qteCount);
    }
    public void StartTensionMeter(float power)
    {
        qteCount = Mathf.FloorToInt(2 * Mathf.Abs(power)); 
        Debug.Log("qteCount = " + qteCount);
        cTension = minT;
        qtedone = 0;
        isTensionIncreasing = true;
        StartNextQTE();
    }

    void Update()
    {
        if (isLineBroken) return;

        if (isQTE)
        {
            qteTimer -= Time.deltaTime;

            if (qteTimer <= 0f)
            {
                nocatch();
            }

            if (Input.GetKeyDown(KeyCode.W) && key == "W")
            {
                SuccessQTE();
            }
            else if (Input.GetKeyDown(KeyCode.A) && key == "A")
            {
                SuccessQTE();
            }
            else if (Input.GetKeyDown(KeyCode.S) && key == "S")
            {
                SuccessQTE();
            }
            else if (Input.GetKeyDown(KeyCode.D) && key == "D")
            {
                SuccessQTE();
            }
        }

        if (isTensionIncreasing == true)
        {
            cTension += speedup * Time.deltaTime;
        }
        else
        {
            cTension -= speeddown * Time.deltaTime;
        }

        cTension = Mathf.Clamp(cTension, minT, MaxT);

        MoveTensionBar(cTension);
    }

    void StartNextQTE()
    {
        if (qteCount > 0)
        {
            isQTE = true;
            qteTimer = qteDuration;

            key = getkey();
            showkey(key);
        }
        else
        {
            Catch();
        }
    }

    string getkey()
    {
        string[] keys = { "W", "A", "S", "D" };
        return keys[Random.Range(0, keys.Length)];
    }

    void showkey(string key)
    {
        switch (key)
        {
            case "W":
                qtepic.sprite = keyw;
                break;
            case "A":
                qtepic.sprite = keya;
                break;
            case "S":
                qtepic.sprite = keys;
                break;
            case "D":
                qtepic.sprite = keyd;
                break;
        }
    }
    

    void MoveTensionBar(float tension)
    {
        float newpos = Mathf.Lerp(-3.07f, -6.67f, (tension - minT) / (MaxT - minT));
        tensionBar.transform.position = new Vector3(newpos, tensionBar.transform.position.y, tensionBar.transform.position.z);
    }

    void SuccessQTE()
    {
        isQTE = false;
        qtedone++;
        isTensionIncreasing = false;  

        
        if (qtedone < qteCount)
        {
            StartNextQTE();
        }
        else
        {
            Catch(); 
        }
    }

    //Fail QTE & Tension is max. This is the lose condition.
    void nocatch()
    {
        isQTE = false;
        isLineBroken = true;
        Debug.Log("QTE Failed");
        Catch();
    }

    void Catch()
    {
        if (qtedone >= qteCount)
        {
            Debug.Log("Catch() - caught the fish!");
            WholeTmeter.SetActive(false);



        }
        else if (qtedone < qteCount)
        {
            Debug.Log("Catch() - lost the fish");
            WholeTmeter.SetActive(false);

        }
        else
        {
            Debug.Log("Error");
        }

        castingMeter.SetActive(true);
        castingbar.SetActive(true);

    }
}

