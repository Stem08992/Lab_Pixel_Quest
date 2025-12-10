using UnityEngine;

public class HW2PlayerRotation : MonoBehaviour
{
    private Camera cam;

    private string camName = "Game_Camera";

    private Vector3 mousePos;

    private void Start()
    {
        cam = GameObject.Find(camName).GetComponent<Camera>();
    }

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 pos = mousePos - transform.position;

        float rotZ = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ - 90);
    }
}
