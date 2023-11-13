using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defultVolume = 1.0f;

    [Header("GammePlay Settings")]
    [SerializeField] private TMP_Text ControllerSensTextValue = null;
    [SerializeField] private Slider ControllerSensSlider = null;
    [SerializeField] private int defultSens = 4;
    public int mainControllerSen = 4; //if I want to change the value of it from the game and script at the same time

    [Header("Toggle Settings")]
    [SerializeField] private Toggle invertYToggle = null;

    [Header("Graphics Settings")]
    [SerializeField] private Slider BrightnessSlider = null;
    [SerializeField] private TMP_Text BrightnessTextValue = null;
    [SerializeField] private float defaultBrightness = 1;

    [Space(10)]
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle fullScreenToggle;

    //the next codes variables to store the qualitiy levels, brightness, and full screen

    private int _qualitiyLevel;
    private bool _isFullScreen;
    private float _brightnessLevel;

    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPropmt = null;


    [Header("Levels To Load")]
    public string _newGameLevel;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;

    

    

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void LoadGameDialogYes()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }
    public void volumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
       
    }
    public void SetControllerSens(float sensitivity)
    {
        mainControllerSen = Mathf.RoundToInt(sensitivity); // to convert from float to int
        ControllerSensTextValue.text = sensitivity.ToString("0");

    }

    public void GamePlayApply()
    {
        if (invertYToggle.isOn) // which means it's true
        {
            PlayerPrefs.SetInt("masterInvertY", 1);
        }
        else
        {
            PlayerPrefs.SetInt("masterInvertY", 0);
        }

        PlayerPrefs.SetFloat("masterSen", mainControllerSen); // to save the volume of the controller
        StartCoroutine(ConfirmationBox()); // to make sure that we saved it
    }

    public void SetBrightness(float brightness)
    {
        _brightnessLevel = brightness;
        BrightnessTextValue.text = brightness.ToString("0.0");
    }

    public void SetFullScreen(bool isFullScreen)
    {
        _isFullScreen = isFullScreen;
    }

    public void SetQuality(int qualityIndex)
    {
        _qualitiyLevel = qualityIndex;
    }

    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", _brightnessLevel); //to save th value of the brightness and apply it
        PlayerPrefs.SetInt("masterQuality", _qualitiyLevel);
        QualitySettings.SetQualityLevel(_qualitiyLevel);

        PlayerPrefs.SetInt("masterFullScreen", (_isFullScreen ? 1 : 0)); //to compare between 1 and zero "like a bool" :)
        Screen.fullScreen = _isFullScreen;
        StartCoroutine(ConfirmationBox());
    }
    public void ResetButton(string MenuType)
    {
        if(MenuType == "Graphics")
        {
            //reset brightness value
            BrightnessSlider.value = defaultBrightness;
            BrightnessTextValue.text = defaultBrightness.ToString("0.0");

            qualityDropdown.value = 1;
            QualitySettings.SetQualityLevel(1);

            fullScreenToggle.isOn = false;
            Screen.fullScreen = false;

            GraphicsApply(); 
        }

        if(MenuType == "Audio")
        {
            AudioListener.volume = defultVolume;
            volumeSlider.value = defultVolume;
            volumeTextValue.text = defultVolume.ToString("0.0");
            volumeApply(); //to make sure that we save these options
        }

        if(MenuType == "Gameplay")
        {
            ControllerSensTextValue.text = defultSens.ToString("0");
            ControllerSensSlider.value = defultSens;
            mainControllerSen = defultSens;
            invertYToggle.isOn = false;
            GamePlayApply();
        }
    }
    public IEnumerator ConfirmationBox()
    {
        //Show a prompt
        //the next function to make sure that we have saved the value of the volume :)
        confirmationPropmt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPropmt.SetActive(false);

    }

}
