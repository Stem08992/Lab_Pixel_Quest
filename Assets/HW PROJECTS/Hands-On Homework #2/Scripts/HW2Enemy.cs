using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW2Enemy : MonoBehaviour
{
    //==================================================================================================================
    // Variables 
    //==================================================================================================================

    //Movement Controls 
    public Rigidbody2D rigidbody2D; //The rigidbody that will move the bullet 
    public float minSpeed = 1f;           //Speed at which the bullet moves 
    public float maxSpeed = 4f;           //Speed at which the bullet moves 

    //Flag and Timer 
    public float deathTime = 100f;   //How long before the bullet dies 
    public bool playerBullet = true; //Is the bullet used by player or enemy 

    // Tags and Names 
    private string boundsTag = "Bounds";
    private string bulletTag = "Bullet";
    private string gameControllerComponent = "GameController";

    // Component 
    private HW2GameController _hw2GameController;

    //==================================================================================================================
    // Base Method  
    //==================================================================================================================

    //Checks who is shooting the bullet and set up the bullet settings 
    private void Start()
    {
        _hw2GameController = GameObject.Find(gameControllerComponent).GetComponent<HW2GameController>();
        StartCoroutine(Death());
    }

    public void SetSpeed(Vector3 newSpeed)
    {
        rigidbody2D.velocity = newSpeed * Random.Range(minSpeed,maxSpeed);
    }

    //==================================================================================================================
    // Bullet Set Up  
    //==================================================================================================================

    //Waits till timer is out then destroys the bullet 
    private IEnumerator Death()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If it touches the bullet, it updates 
        if (collision.gameObject.tag == bulletTag)
        {
            //Updates the Score 
            _hw2GameController.UpdateScore();
            //Destorys the bullet
            Destroy(collision.gameObject);
            //Destorys the enemy 
            Destroy(gameObject);
        }
        // If the enemy touches a bound it gets destored 
        else if(collision.gameObject.tag == boundsTag)
        {
            Destroy(gameObject);
        }
    }
}
