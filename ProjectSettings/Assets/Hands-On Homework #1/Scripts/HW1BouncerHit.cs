using UnityEngine;

public class HW1BouncerHit : MonoBehaviour
{
    //==================================================================================================================
    // Variables  
    //==================================================================================================================
    //The pre fab text that will spawn 
    [SerializeField] private GameObject preFab;
    //Animator that will make the bounce animate 
    private  Animator _animator;
    //Value of hitting a bouncer 
    private const int Score = 5;
    //Used to pass the value to the game flow script 
    private HW1GameFlow _hw1GameFlow;
    //Plays SFX when the player hits the bouncer 
    private AudioSource _audioSource;

    //==================================================================================================================
    // Variables  
    //==================================================================================================================
    
    //Connects components 
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _hw1GameFlow = GameObject.Find("GameFlow").GetComponent<HW1GameFlow>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    //==================================================================================================================
    // On Collision Method   
    //==================================================================================================================
    private void OnCollisionEnter2D(Collision2D col)
    {
        //Start the hit animation 
        _animator.Play($"BallHit");
        //Passes in the score 
        _hw1GameFlow.ScorePoint(Score);
        //Creates the text and passes the number to it
        var score = Instantiate(preFab, transform.position, Quaternion.identity);
        score.GetComponent<HW1ScoreAdd>().SetValue(Score);
        //Plays the SFX 
        _audioSource.Play();
    }
}
