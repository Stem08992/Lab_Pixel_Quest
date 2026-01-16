//using System.Threading;
//using Unity.PlasticSCM.Editor.WebApi;
//using UnityEngine;

//public class HW2PlayerShoot : MonoBehaviour
//{
//    public GameObject preFab1;
//    public GameObject preFab2;
//    public Transform bulletTrash;
//    public Transform bulletSpawn;

//    private const float Timer = 0.5f;
//    private bool canShoot = true;
//    private float _currentTime = 0.5f;

//    public void canShootFunc()
//    {
//        if (!canShoot)
//        {
//            _currentTime -= Time.deltaTime;

//            if (_currentTime < 0)
//            {
//                canShoot = true;
//                _currentTime = Timer;
//            }
//        }
//    }

//    public void shootFunc()
//    {
//        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
//        {
//            GameObject bullet1 = Instantiate(preFab1, bulletSpawn.position, Quaternion.identity);
//            bullet1.transform.SetParent(bulletTrash);
//            canShoot = false;
//        }
//        else if (Input.GetKeyDown(KeyCode.Mouse1) && canShoot)
//        {
//            GameObject bullet2 = Instantiate(preFab2, bulletSpawn.position, Quaternion.identity);
            
//            bullet2.transform.SetParent(bulletTrash);
//            canShoot = false;
//        }
//    }
    

//    private void Update()
//    {
//        canShootFunc();
//        shootFunc();


//    }
//}
