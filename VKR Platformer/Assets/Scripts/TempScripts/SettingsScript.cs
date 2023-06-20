using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;

    public Slider slider;

    Resolution[] resolutions;

    private void Start()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();

        slider.SetValueWithoutNotify(PlayerPrefs.GetFloat("AudioVolume"));

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetFullScreen(bool isFullSreen)
    {
        Screen.fullScreen = isFullSreen;
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("AudioVolume", volume);
        audioMixer.SetFloat("volume", volume);
        AudioListener.volume = volume;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void BackToMenu()
    {
        audioSource.PlayOneShot(audioSource.clip);
        SceneManager.LoadScene("MainMenu");
    }
}
