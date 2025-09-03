using UnityEngine;

public class HW2PlayerShoot : MonoBehaviour
{
    public GameObject preFab;
    public GameObject preFab2;
    public Transform bulletTrash;
    public Transform bulletSpawn;

    private const float Timer = 0.5f;
    private float _currentTime = 0.5f;
    private bool _canShoot = true;

    private void Update()
    {

        TimerMethod();
        PlayerShoot();
    }

    private void TimerMethod()
    {
        if (!_canShoot)
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime <= 0)
            {
                _canShoot = true;
                _currentTime = Timer;
            }
        }

    }

    private void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _canShoot)
        {
            _canShoot = false;
            GameObject bullet = Instantiate(preFab, bulletSpawn.position, Quaternion.identity);
            bullet.transform.SetParent(bulletTrash);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && _canShoot)
        {
            _canShoot = false;
            GameObject bullet_2 = Instantiate(preFab2, bulletSpawn.position, Quaternion.identity);
            bullet_2.transform.SetParent(bulletTrash);
        }
    }
} 