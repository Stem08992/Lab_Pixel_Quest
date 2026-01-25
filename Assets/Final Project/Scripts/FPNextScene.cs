using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPNextScene : MonoBehaviour
{
    public List<string> sceneList;
    public static int currentSceneIndex = 0;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        Debug.Log(currentSceneIndex + sceneList[currentSceneIndex]);
        GameObject orderObj = GameObject.FindGameObjectWithTag("OrderData");
        if (orderObj != null)
        {
            FPOrderData orderData = orderObj.GetComponent<FPOrderData>();
            if (orderData != null)
            {

                orderData.CheckScore();
 
            }
        }

        SceneManager.LoadScene(sceneList[currentSceneIndex]);

        currentSceneIndex++;
        if (currentSceneIndex >= sceneList.Count)
            currentSceneIndex = 0; 

    }
}
