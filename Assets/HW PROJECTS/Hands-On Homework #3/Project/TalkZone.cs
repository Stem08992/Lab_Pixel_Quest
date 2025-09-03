using UnityEngine;

public class TalkZone : MonoBehaviour
{
    //========== Display Items 
    public Sprite sprite;           //Holds the sprite that will show up with next to the text
    public string[] sentences;      //Holds all the lines the person will say 
    
    //==================================================================================================================
    // Functions 
    //==================================================================================================================
    
    //If the player goes into the zone play the welcome sound 
    private void OnTriggerEnter2D(Collider2D hitBox)
    {
        if (!hitBox.CompareTag($"Ship")) return;
        GetComponent<AudioSource>().Play();
    }
}
