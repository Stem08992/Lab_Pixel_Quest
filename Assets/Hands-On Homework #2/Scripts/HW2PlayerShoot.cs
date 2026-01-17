using UnityEngine;

public class HW2PlayerShoot : MonoBehaviour
{
    public GameObject preFab;           // Left-click bullet
    public GameObject altPreFab;        // Right-click bullet
    public Transform bulletTrash;
    public Transform bulletSpawn;

    private const float LeftCooldown = 0.5f;
    private const float RightCooldown = LeftCooldown / 2.5f; // 2.5x faster

    private float _leftTimer = 0f;
    private float _rightTimer = 0f;

    private void Update()
    {
        if (_leftTimer > 0) _leftTimer -= Time.deltaTime;
        if (_rightTimer > 0) _rightTimer -= Time.deltaTime;

        // Left-click: regular bullet
        if (Input.GetMouseButtonDown(0) && _leftTimer <= 0)
        {
            GameObject bullet = Instantiate(preFab, bulletSpawn.position, Quaternion.identity);
            bullet.transform.SetParent(bulletTrash);
            _leftTimer = LeftCooldown;
        }

        // Right-click: faster bullet
        if (Input.GetMouseButtonDown(1) && _rightTimer <= 0)
        {
            GameObject altBullet = Instantiate(altPreFab, bulletSpawn.position, Quaternion.identity);
            altBullet.transform.SetParent(bulletTrash);
            _rightTimer = RightCooldown;
        }
    }
}
