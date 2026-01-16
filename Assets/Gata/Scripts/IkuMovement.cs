using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IkuMovement : MonoBehaviour
{
    private Character Iku;
    private string Phase;
    private float xDif;
    private float yDif;
    private float dis;
    private Rigidbody2D _rigidbody;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    private float Timer;
    private float currentTime;
    private float xRandom;
    private float yRandom;
    private int counter;
    public string nextLevel = "End";

    // Start is called before the first frame update
    void Start()
    {
        Iku = GetComponent<Character>();
        Phase = "one";
        _rigidbody = GetComponent<Rigidbody2D>();
        minX = -1;
        maxX = 1;
        minY = -1;
        maxY = 1;
        Timer = 2;
        currentTime = 2;
        xRandom =Random.Range(minX, maxX);
        yRandom = Random.Range(minY, maxY);
        counter = 1;
    }

    void movementPhase1()
    {
        xDif = transform.position.x - GameObject.Find("Rintaro").transform.position.x;
        yDif = transform.position.y - GameObject.Find("Rintaro").transform.position.y;
        //print(_rigidbody.velocity);
        dis = Mathf.Sqrt(Mathf.Pow(xDif,2) + Mathf.Pow(yDif, 2));
        //print("distance" + dis);
        //print(xRandom + "xran");
        if (dis < 6)
        {
            //print("go away");
            _rigidbody.velocity = new Vector2(xDif, yDif).normalized*Iku.playerSpeed;
        } else if (dis > 12)
        {
            //print("approach");
            _rigidbody.velocity = new Vector2(-xDif, -yDif).normalized * Iku.playerSpeed;
        }
        else
        {
            if (xDif > yDif)
            {
                //print("who know");
                _rigidbody.velocity = new Vector2(xRandom*.1f, yRandom).normalized * Iku.playerSpeed;
            } else
            {
                _rigidbody.velocity = new Vector2(xRandom, yRandom*.1f).normalized * Iku.playerSpeed;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        //print(currentTime);
        if(currentTime <= 0)
        {
            counter++;
            currentTime = Timer;
            //print(xRandom + "x ran");
            xRandom = Random.Range(minX, maxX);
            yRandom = Random.Range(minY, maxY);
            if(counter >= 3)
            {
                counter = 1;
                xRandom = -xDif;
                yRandom = -yDif;
            }
            if (Phase.Equals("one"))
            {
                movementPhase1();
            }
            if (Phase.Equals("two"))
            {
                movementPhase1();
            }
        }
        if(Iku.health <= 0)
        {
            SceneManager.LoadScene(nextLevel);
        }

        //print(Phase);
        //print(Phase.Equals("one"));
        //print(Iku.health);   
        if(Iku.health < 35)
        {
            Phase = "two";
        }
    }
}
