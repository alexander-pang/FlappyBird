using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject easyToggle;
    public GameObject soundToggle;
    public GameObject musicToggle;
    // Start is called before the first frame update
    void Start()
    {
        int isEasy = PlayerPrefs.GetInt("IsEasyMode", 0);
        int soundAlert = PlayerPrefs.GetInt("SoundAlertOn", 0);
        int music = PlayerPrefs.GetInt("MusicOn", 0);

        if (isEasy == 1)
        {
            easyToggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            easyToggle.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "O";
        }

        if (soundAlert == 1)
        {
            soundToggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            soundToggle.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "O";
        }

        if (music == 1)
        {
            musicToggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            musicToggle.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "O";
        }

    }

    public void isEasyChanged()
    {
        bool isOn = easyToggle.GetComponent<Toggle>().isOn;
        if (isOn)
        {
            PlayerPrefs.SetInt("IsEasyMode", 1);
            easyToggle.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "X";
        }
        else
        {
            PlayerPrefs.SetInt("IsEasyMode", 0);
            easyToggle.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "O";
        }
    }

    public void isSoundChanged()
    {
        bool isOn = soundToggle.GetComponent<Toggle>().isOn;
        if (isOn)
        {
            PlayerPrefs.SetInt("SoundAlertOn", 1);
            soundToggle.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "X";
        }
        else
        {
            PlayerPrefs.SetInt("SoundAlertOn", 0);
            soundToggle.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "O";
        }
    }

    public void isMusicChanged()
    {
        
        bool isOn = musicToggle.GetComponent<Toggle>().isOn;
        UnityEngine.Debug.Log(isOn);
        if (isOn)
        {
            PlayerPrefs.SetInt("MusicOn", 1);
            musicToggle.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "X";
            FindObjectOfType<AudioManager>().PlayIfNotPlaying("ThemeSong");
        }
        else
        {
            UnityEngine.Debug.Log(isOn);
            PlayerPrefs.SetInt("MusicOn", 0);
            musicToggle.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "O";
            FindObjectOfType<AudioManager>().Stop("ThemeSong");
        }
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
