using UnityEngine;

public class HW2PlayerShoot : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab2;
    public Transform bulletTrash;
    public Transform bulletSpawn;

    private const float Timer = 0.5f;
    private float currentTime = 0.5f;
    private bool canShoot = true; 

    private void Update()
    {
        TimerMethod();

        ShootLeft();

        ShootRight();
    }

    private void TimerMethod()
    {
        if (!canShoot)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
            {
                canShoot = true;
                currentTime = Timer;
            }
        }
    }

    private void ShootLeft()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            GameObject bullet = Instantiate(prefab, bulletSpawn.position, Quaternion.identity);

            bullet.transform.SetParent(bulletTrash);

            canShoot = false;
        }
    }

    private void ShootRight()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && canShoot)
        {
            GameObject bullet2 = Instantiate(prefab2, bulletSpawn.position, Quaternion.identity);

            bullet2.transform.SetParent(bulletTrash);

            canShoot = false;
        }
    }
}
