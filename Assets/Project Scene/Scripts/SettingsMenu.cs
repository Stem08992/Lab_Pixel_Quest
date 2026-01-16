using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public Toggle musicToggle;
    public Toggle fullscreenToggle;
    public TMP_Dropdown qualityDropdown;

    [Header("Audio")]
    public AudioSource musicSource;

    void Start()
    {
        // -------------------
        // Load Saved Settings
        // -------------------

        // Music toggle (default ON)
        bool musicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
        musicToggle.SetIsOnWithoutNotify(musicOn);
        ApplyMusic(musicOn);

        // Fullscreen toggle (default ON)
        bool fullscreenOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        fullscreenToggle.SetIsOnWithoutNotify(fullscreenOn);
        ApplyFullscreen(fullscreenOn);

        // Graphics quality (default current quality)
        int savedQuality = PlayerPrefs.GetInt("Quality", QualitySettings.GetQualityLevel());
        qualityDropdown.SetValueWithoutNotify(savedQuality);
        ApplyQuality(savedQuality);
    }

    // -------------------
    // Music Toggle
    // -------------------
    public void ToggleMusic(bool isOn)
    {
        ApplyMusic(isOn);
        PlayerPrefs.SetInt("MusicOn", isOn ? 1 : 0);
    }

    void ApplyMusic(bool isOn)
    {
        if (isOn)
        {
            if (!musicSource.isPlaying)
                musicSource.Play();
        }
        else
        {
            musicSource.Stop();
        }
    }

    // -------------------
    // Fullscreen Toggle
    // -------------------
    public void ToggleFullscreen(bool isOn)
    {
        ApplyFullscreen(isOn);
        PlayerPrefs.SetInt("Fullscreen", isOn ? 1 : 0);
    }

    void ApplyFullscreen(bool isOn)
    {
        Screen.fullScreen = isOn;
    }

    // -------------------
    // Graphics Quality
    // -------------------
    public void ChangeQuality(int qualityIndex)
    {
        ApplyQuality(qualityIndex);
        PlayerPrefs.SetInt("Quality", qualityIndex);
    }

    void ApplyQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
