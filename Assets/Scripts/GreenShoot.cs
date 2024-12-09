using UnityEngine;

public class GreenShoot : MonoBehaviour
{
    // Prefab 
    public GameObject preFab;
    public Transform bulletTrash;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;

    // Timer 
    private const float Timer = 0.5f;
    private float _currentTime = 0.5f;
    private bool _canShoot = true;
    private SpriteRenderer playerRenderer;

    private void Update()
    {
        //Get Player Sprite redener
        playerRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        BulletSpawnTimer();
        SpawnBullet();
    }

    // Counts down until the player can shoot again
    private void BulletSpawnTimer()
    {
        // If can shoot don't do anything
        if (_canShoot) return;
        // If can't shoot count down till you can
        _currentTime -= Time.deltaTime;

        // If the time is larnger than zero don't do anyhting
        if(_currentTime > 0) { return; }
        // If it's less than 0 reset the timer and allow player to shoot
        _currentTime = Timer;
        _canShoot = true;
    }

    // Creates the bullet
    private void SpawnBullet()
    {
        // If the player can't shoot or is clicking a diffrent key don't do anything
        if (!Input.GetKey(KeyCode.T) || !_canShoot) { return; }
        // Create a copy of the bullet
        var bullet = Instantiate(preFab, playerRenderer.flipX ? bulletSpawn2.position : bulletSpawn1.position, Quaternion.identity);
   
        // Connect the bullet to a trash collector object
        bullet.transform.SetParent(bulletTrash);
        bullet.tag = "GreenBullet";
        //Get Sprite player flip
        bullet.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = !playerRenderer.flipX;
        // Stop player from being able to shoot
        _canShoot = false;
    }
}