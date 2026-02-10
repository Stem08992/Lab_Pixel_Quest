using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FPToggle : MonoBehaviour, IPointerClickHandler
{
    public GameObject target;
    public void OnPointerClick(PointerEventData eventData)
    {
        target.SetActive(!target.activeSelf);
    }
}
