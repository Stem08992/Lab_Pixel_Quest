using System.Threading;
using UnityEngine;

public class HW2PlayerShoot : MonoBehaviour
{
    public GameObject preFab;
    public GameObject preFad;
    public Transform bulletTrash;
    public Transform bulletSpawn;


    private float _currentTime = 0.5f;
    private bool _canShoot = true;
    private const float Timer = 0.5f;
    
    private void Update()
    {
        TimerMeathod();

        if (Input.GetKeyDown(KeyCode.Mouse0) && _canShoot)

        {
         
            
            GameObject bullet = Instantiate(preFab, bulletSpawn.position, Quaternion.identity);

            bullet.transform.SetParent(bulletTrash);


            _canShoot=false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)&& _canShoot)

        {
            Debug.Log("a");

            GameObject bullet = Instantiate(preFad,bulletSpawn.position, Quaternion.identity);

            bullet.transform.SetParent(bulletTrash);


            _canShoot = false;
        }

    }

    private void TimerMeathod()
    {
        if (!_canShoot)
        {
            
            _currentTime -= Time.deltaTime;

            if(_currentTime < 0)
            {
                _canShoot = true;
                _currentTime = Timer;
            }
        }
    }
}