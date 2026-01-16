using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class LevelUnlock : MonoBehaviour
{

    public int cost;
    public TextMeshPro costtext;
    private void Start()
    {
        costtext= GetComponentInChildren<TextMeshPro>();
        costtext.text = "$" + cost.ToString();
    }
    

}
