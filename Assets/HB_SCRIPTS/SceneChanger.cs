using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    private enum FadeStatus
    {
        FadingIn,
        FadingOut,
        None
    }

    public static SceneChanger Instance;

    [Header("Fade Settings")]
    public Image fadeImage;
    public float fadeDuration = 1f;

    private FadeStatus currentFadeStatus = FadeStatus.None;
    private float fadeTimer = 0f;
    private string sceneToLoad = "";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Start with a full black screen, then fade in
        fadeImage.color = Color.black;
        currentFadeStatus = FadeStatus.FadingIn;
        fadeTimer = 0f;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Start fading in after the new scene loads
        fadeTimer = 0f;
        currentFadeStatus = FadeStatus.FadingIn;
    }

    public void ChangeScene(string sceneName)
    {
        if (currentFadeStatus == FadeStatus.None)
        {
            sceneToLoad = sceneName;
            fadeTimer = 0f;
            currentFadeStatus = FadeStatus.FadingOut;
        }
    }

    private void Update()
    {
        if (currentFadeStatus == FadeStatus.None)
            return;

        fadeTimer += Time.deltaTime;
        float progress = fadeTimer / fadeDuration;

        if (progress >= 1f)
        {
            if (currentFadeStatus == FadeStatus.FadingOut)
            {
                fadeImage.color = Color.black;
                SceneManager.LoadScene(sceneToLoad);
                // Fade-in will be triggered by OnSceneLoaded
            }
            else if (currentFadeStatus == FadeStatus.FadingIn)
            {
                fadeImage.color = Color.clear;
                currentFadeStatus = FadeStatus.None;
            }

            fadeTimer = 0f;
        }
        else
        {
            float alpha = (currentFadeStatus == FadeStatus.FadingOut)
                ? Mathf.Lerp(0f, 1f, progress)
                : Mathf.Lerp(1f, 0f, progress);

            fadeImage.color = new Color(0f, 0f, 0f, alpha);
        }
    }
}
