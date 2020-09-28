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
    // Start is called before the first frame update
    void Start()
    {
        int isEasy = PlayerPrefs.GetInt("IsEasyMode", 0);
        int soundAlert = PlayerPrefs.GetInt("SoundAlertOn", 0);

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
            UnityEngine.Debug.Log("Hi");
            PlayerPrefs.SetInt("SoundAlertOn", 1);
            soundToggle.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "X";
        }
        else
        {
            PlayerPrefs.SetInt("SoundAlertOn", 0);
            soundToggle.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "O";
        }
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
