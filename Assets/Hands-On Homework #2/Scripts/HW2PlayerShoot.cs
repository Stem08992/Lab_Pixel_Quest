using UnityEngine;

public class HW2PlayerShoot : MonoBehaviour
{
    public GameObject preFab;
    public GameObject bombPreFab;
    public Transform bulletTrash;
    public Transform bulletSpawn;

    private bool canShootRegular = true;
    private bool canShootBomb = true;

    private const float Timer = 0.5f;
    private float currentTime = 0.5f;
    private const float bombTimer = 2f;
    private float bombCurrentTime = 2f;
    private void Update()
    {
        TimerMethod();
        shootMethod();
        
    }
    private void shootMethod()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShootRegular)
        {
            GameObject bullet = Instantiate(preFab, bulletSpawn.position, Quaternion.identity);
            bullet.transform.SetParent(bulletTrash);
            canShootRegular = false;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && canShootBomb)
        {
            GameObject bullet = Instantiate(bombPreFab, bulletSpawn.position, Quaternion.identity);
            bullet.transform.SetParent(bulletTrash);
            canShootBomb = false;
        }
    }
    private void TimerMethod()
    {
        if (!canShootRegular)
        {
            currentTime -= Time.deltaTime;

            if (currentTime < 0)
            {
                canShootRegular = true;
                currentTime = Timer;
            }
        }
        if(!canShootBomb)
        {
            bombCurrentTime -= Time.deltaTime;
            if(bombCurrentTime < 0)
            {
                canShootBomb = true;
                bombCurrentTime = bombTimer;
            }
        }
    }
}
