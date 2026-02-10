using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FPGuide : MonoBehaviour
{
    public Image book;
    public List<Sprite> pages;
    private int currentPage = 0;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        book.sprite = pages[currentPage];

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentPage < pages.Count - 1)
            {
                currentPage++;
            }
        }
    
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentPage > 0)
            {
                currentPage--;
            }
        }
    }
  }


