using System.Collections;
using UnityEngine;

//Controls the bullet that can hit player on Enemy 
public class Bullet : MonoBehaviour
{
    //==================================================================================================================
    // Variables 
    //==================================================================================================================

    //Used by Player Spawner 
    private Camera _camera;    //Camera Game Object 
    private Vector3 _mousePos; //Current Mouse Position  

    //Movement Controls 
    private Rigidbody2D _rigidbody2D; //The rigidbody that will move the bullet 
    public float speed;           //Speed at which the bullet moves 

    //Flag and Timer 
    public float deathTime = 3f;   //How long before the bullet dies 
    public bool playerBullet = true; //Is the bullet used by player or enemy 

    //==================================================================================================================
    // Base Method  
    //==================================================================================================================

    //Checks who is shooting the bullet and set up the bullet settings 
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(Death());
    }

    //==================================================================================================================
    // Bullet Set Up  
    //==================================================================================================================

    private void Update()
    {
        SpriteRenderer playerRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (playerRenderer.flipX) speed = 20;
        else speed = -20;
        transform.position += new Vector3(speed *Time.deltaTime, 0, 0);
    }

    //Waits till timer is out then destroys the bullet 
    private IEnumerator Death()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }
}