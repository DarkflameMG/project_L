using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class options : MonoBehaviour
{

    [SerializeField]
    private GameObject option;

    public AudioMixer audioMixer;

    [SerializeField]
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        option.SetActive(false);

        resolutionDropdown.ClearOptions();

        List<string> listOption = new List<string>();


        int currentResolutionIndex = 0;
        for(int i = 0;i < resolutions.Length;i++)
        {
            string op = resolutions[i].width + " x " + resolutions[i].height;
            listOption.Add(op);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }

        resolutionDropdown.AddOptions(listOption);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",Mathf.Log10(volume)*20);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex); 
    }

    public void SetFullscreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }

    private void Awake()
    {
        option.SetActive(false);
    }

    public void exit()
    {
        option.SetActive(false);
    }





}
