using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // For scene management

public class GameManagerButtonHandler : MonoBehaviour
{
    public Button button; // Reference to the UI button
    public enum ActionType { ChangeValues, AdvanceScene }
    public ActionType actionType;

    // For ChangeValues action
    public float popularityDelta = 0f;
    public float trafficDelta = 0f;
    public float pollutionDelta = 0f;
    public float revenueDelta = 0f;

    public string sceneToLoad; // Name of the scene to load for AdvanceScene action

    void Start()
    {
        if (button == null)
            button = GetComponent<Button>(); // Attach Button if not assigned in the Inspector

        button.onClick.AddListener(OnButtonClick);
    }




    void OnButtonClick()
    {
        switch (actionType)
        {
            case ActionType.ChangeValues:
                ChangeGameValues();
                break;

            case ActionType.AdvanceScene:
                AdvanceToNextScene();
                break;
        }
    }

    void ChangeGameValues()
    {
        GameManager.Instance.UpdateBarValues(popularityDelta, trafficDelta, pollutionDelta, revenueDelta);
    }

    void AdvanceToNextScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene name is not set!");
        }
    }
}