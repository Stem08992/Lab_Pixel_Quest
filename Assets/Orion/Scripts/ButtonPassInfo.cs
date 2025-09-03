using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPassInfo : MonoBehaviour
{
    [Tooltip("pop, tra. pol, revb")]
    public float[] vals = {1,2,3,4};
    public string nextLevel;
    public void PassInfoFunction()
    {
        GameManager.Instance.UpdateBarValues(vals[0], vals[1], vals[2], vals[3]);
        SceneManager.LoadScene(nextLevel);
    }
}
