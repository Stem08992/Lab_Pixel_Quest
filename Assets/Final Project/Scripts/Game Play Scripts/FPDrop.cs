using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour
{
    public bool isInDropZone = false;
    public GameObject Player;
    public GameObject Minigame;


    public void OnMouseEnter()
    {
        isInDropZone = true;

    }

    public void OnMouseExit()
    {
        isInDropZone = false;
    }

    private void OnMouseDown()
    {

        if (isInDropZone && Player.transform.childCount > 0)
        {
            Player.transform.GetChild(0).SetParent(transform);
            transform.GetChild(transform.childCount - 1).localPosition = Vector3.zero;

            Minigame.SetActive(true);
        }
        else if (isInDropZone && transform.childCount > 0)
        {
            transform.GetChild(0).SetParent(Player.transform);
            Player.transform.GetChild(0).localPosition = Vector3.zero;

        }

    }

}

