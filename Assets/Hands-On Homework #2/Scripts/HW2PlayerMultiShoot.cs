using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW2PlayerMultiShoot : MonoBehaviour
{
    public GameObject prefab;
    public Transform bulletTrash;
    public Transform bulletSpawn;

    private bool _canShoot = true;

    private const float Timer = 3f;
    private float _currentTime = 3f;
    private int _bulletCount = 0;
    private int _bulletMax = 5;
    private void Update()
  
    {
        TimerMethod();
        Shoot();
    }

    private void TimerMethod()
    {
        if (!_canShoot)
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime < 0)
            {
                _canShoot = true;
                _currentTime = Timer;
                _bulletCount = 0;

            }
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && _canShoot)
        {
            GameObject bullet = Instantiate(prefab, bulletSpawn.position, Quaternion.identity);

            bullet.transform.SetParent(bulletTrash);

            _bulletCount++;

            if (_bulletCount > _bulletMax)
            {
                _canShoot = false;
            }
        }
    }
}
