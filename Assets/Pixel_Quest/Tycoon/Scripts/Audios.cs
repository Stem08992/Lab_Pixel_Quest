using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    public AudioSource coinsfx;
    public AudioSource heartsfx;
    public AudioSource deathsfx;
    public AudioSource checkpointsfx;
    public void playaudio(string name)
    {
        switch (name.ToLower())
        {
            case "Coin":
                {
                    coinsfx.Play();
                    break;
                }
            case "Checkpoint":
                {
                    checkpointsfx.Play();
                    break;
                }
            case "Heart":
                {
                    heartsfx.Play();
                    break;
                }
            case "Death":
                {
                    deathsfx.Play();
                    break;
                }
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
