using UnityEngine;
using UnityEngine.EventSystems;

public class FPTrash : MonoBehaviour, IPointerClickHandler
{
    public Transform Player;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Player.childCount >= 1)
        {
            Destroy(Player.GetChild(0).gameObject);
        }
    }
}