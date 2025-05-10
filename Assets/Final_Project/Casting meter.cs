using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerCastingMeter : MonoBehaviour
{
    public GameObject bar;
    public GameObject meter;
    public TensionMeter tensionMeter;
    public GameObject WholeTmeter;
    public float minP = -5f;
    public float MaxP = 5f;
    public float oSpeed = 5f;
    public float speed = 1f;
    private float cpower = 0f;
    private bool isCharging = false;
    private bool increasing = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isCharging = true;
            cpower = minP;
            increasing = true;
            bar.SetActive(true);
            meter.SetActive(true);

        }

        if (Input.GetMouseButton(0) && isCharging)
        {
            float delta = oSpeed * Time.deltaTime;

            if (increasing)
                cpower += delta;
            else
                cpower -= delta;

            if (cpower >= MaxP)
            {
                cpower = MaxP;
                increasing = false;
            }
            else if (cpower <= minP)
            {
                cpower = minP;
                increasing = true;
            }


            barmovingfunction(cpower);
        }

        if (Input.GetMouseButtonUp(0) && isCharging)
        {
            isCharging = false;
            powerfunctionfunction(cpower);
            //cpower = 0f;
            bar.SetActive(false);
            meter.SetActive(false);
            WholeTmeter.SetActive(true);
        }
    }

    void barmovingfunction(float power)
    {
        float barpos = Mathf.Lerp(3f, 7f, (power - minP) / (MaxP - minP));
        tensionMeter.StartTensionMeter(barpos);
        bar.transform.position = new Vector3(barpos * speed, bar.transform.position.y, bar.transform.position.z);
    }

    void powerfunctionfunction(float power)
    {
        Debug.Log("Casting with power: " + power);

    }
}