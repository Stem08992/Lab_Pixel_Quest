using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkuAttack : MonoBehaviour
{
    private Character Iku;
    private GameObject Rin;
    private float timer;
    private float currentTime;
    private float currentDegree;
    private float targetDegree;
    private int polarity;
    private Vector3 bulletTarget;
    private int counter;
    private Vector3 phase2Attack;

    // Start is called before the first frame update
    void Start()
    {
        phase2Attack = this.transform.position;
        counter = 0;
        Iku = GetComponent<Character>();
        Rin = GameObject.Find("Rintaro");
        timer = 2;
        currentTime = timer;
        targetDegree = 180;
        currentDegree = targetDegree;
        polarity = 1;
    }

    void phaseOneTargeting()
    {

    }

    void bulletMaker(Vector3 target)
    {
        GameObject bullet1 = Instantiate(Iku.getMove(0).gameObject, Iku.bulletSpawn.position, Quaternion.identity);
        bullet1.GetComponent<Move>().setTarget(target);
        bullet1.SetActive(true);
        bullet1.transform.SetParent(Iku.bulletTrash);
        Iku.getMove(0).setShoot(false);
    }

    public void fireShoot(int bulletAmount, Vector3 target)
    {

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject bullet1 = Instantiate(Iku.getMove(0).gameObject, Iku.bulletSpawn.position, Quaternion.identity);
            bullet1.GetComponent<Move>().setTarget(target);
            bullet1.SetActive(true);
            bullet1.transform.position += new Vector3(UnityEngine.Random.Range(-4f, 4f), UnityEngine.Random.Range(-4f, 4f), 0);
            bullet1.GetComponent<Rigidbody2D>().velocity = bullet1.transform.forward * 3000;
        }
        //}
    }

    void timerFunc()
    {
        currentTime -= Time.deltaTime;
        currentDegree -= targetDegree / (2 / Time.deltaTime) * polarity;
        if (currentTime <= 0)
        {
            currentTime = this.timer;
            currentDegree = targetDegree * polarity;
            polarity *= -1;
            if(counter == 0)
            {
                counter++;
                phase2Attack = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10), 0).normalized;
            } else if (counter == 1)
            {
                counter++;
                phase2Attack = Rin.transform.position.normalized;
            } else
            {
                phase2Attack = this.transform.position.normalized;
                counter = 0;
            }
        }
    }


    Vector3 vectorRot(Vector3 target)
    {
        return Quaternion.AngleAxis(currentDegree, Vector3.up) * target;
    }

    void Update()
    {
        timerFunc();

        Iku.getMove(0).setTarget(Rin.transform.position);
        //print(Iku.getMove(0).getTarget() + "Iku target");
        //print(Iku.getMove(0).getTarget());
        Iku.canShootFunc(0);
        if (Iku.health > 35 && Iku.getMove(0).getShoot())
        {
            //.getMove(0) finds the baseball attack used by iku
            bulletTarget = vectorRot(Rin.transform.position);
            bulletMaker(bulletTarget);      
        }
        else if(Iku.health <= 35 && currentTime <= .02)
        {
            Iku.getMove(0)._moveSpeed = 8;
            print(Iku.getMove(0)._cooldown + " cooldown");
            fireShoot(10, phase2Attack);
            
        }
    }
}
