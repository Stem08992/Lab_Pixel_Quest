using UnityEngine;

public class HW2PlayerShoot : MonoBehaviour
{
    public GameObject preFab;
    public Transform bulletTrash;
    public Transform bulletSpawn;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(preFab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.transform.SetParent(bulletTrash);
        }
    }
}
