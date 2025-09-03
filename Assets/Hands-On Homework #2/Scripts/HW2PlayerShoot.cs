using UnityEngine;

public class HW2PlayerShoot : MonoBehaviour
{
    public GameObject perFab;
    public Transform bulletTrash;
    public Transform bulletSpawn;

    private const float Timer = 0.5f;
    private float _currenTime = 0.5f;
    private bool _canShoot = true;
    private void Update()
    {
        TimerMethod();
        Shoot();

        
    }

    private void TimerMethod()
    {
        if (!_canShoot)
        {
            _currenTime -= Time.deltaTime;
            if (_currenTime < 0)
            {
                _canShoot = true;
                _currenTime = Timer;
            }
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _canShoot)
        {
            GameObject bullet = Instantiate(perFab, bulletSpawn.position, Quaternion.identity);

            bullet.transform.SetParent(bulletTrash);
            _canShoot = false;
        }
    }


}
