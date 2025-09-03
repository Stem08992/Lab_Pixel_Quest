using UnityEngine;

public class HW2PlayerRotation : MonoBehaviour
{
    private Camera camera;

    private string CameraName = "Game_Camera";
    private Vector3 positionMouse;
    public void Start()
    {
        camera = GameObject.Find(CameraName).GetComponent<Camera>();
    }

    private void Update()
    {
        positionMouse = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos = positionMouse - transform.position;
        float rotZ = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ - 90);
    }
}
