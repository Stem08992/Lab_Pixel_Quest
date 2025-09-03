using UnityEngine;

public class HW1EndGoal : MonoBehaviour
{
    //==================================================================================================================
    // Variables  
    //==================================================================================================================
    
    //Used to tell how much the points the end goal gives out 
    [SerializeField] private int score;
    //Used to create the text that shows points scored 
    [SerializeField] private GameObject preFab;
    //Used to tell where the text should spawn 
    private Transform _spawnPoint;
    //Used to tell the shooting script that player can click the button 
    private HW1Shooter _hw1Shooter;
    //Used to tell the game flow script how many points the player earned 
    private HW1GameFlow _hw1GameFlow;
    //Used to play a SFX for player reaching the end goal 
    private AudioSource _audioSource;
    
    //==================================================================================================================
    // Base Methods  
    //==================================================================================================================
    
    //Connects all of the components 
    private void Start()
    {
        _hw1Shooter = GameObject.Find("Shooter").GetComponent<HW1Shooter>();
        _hw1GameFlow = GameObject.Find("GameFlow").GetComponent<HW1GameFlow>();
        _audioSource = GetComponent<AudioSource>();
        _spawnPoint = transform.GetChild(0).transform;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        //Passes on the score 
        _hw1GameFlow.ScorePoint(score);
        //Creates the prefab and updates it's value 
        var instantiate = Instantiate(preFab, _spawnPoint.position, Quaternion.identity);
        instantiate.GetComponent<HW1ScoreAdd>().SetValue(score);
        //Resets button 
        _hw1Shooter.ResetButton();
        //Plays SFX 
        _audioSource.Play();
        //Destroys the ball 
        Destroy(other.gameObject);
    }
}
