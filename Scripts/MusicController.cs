using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MusicController : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private AudioListener audioListener;
    [SerializeField] private bool IsMusicOn;

    private string choiceSave;

    private void Start()
    {
        LoadData();
        IsMusicOn = toggle.isOn;
    }

    public void toggleMusic (bool isMusicOn)
    {
        IsMusicOn = toggle.isOn;
        if (IsMusicOn == true)
        {
            AudioListener.volume = 1;
        }
        else AudioListener.volume = 0;
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    private void LoadData()
    {
        bool choiceLoad = Convert.ToBoolean(PlayerPrefs.GetString("choiceSave", choiceSave));
        toggle.isOn = choiceLoad;
    }

    private void SaveData()
    {
        choiceSave =  toggle.isOn.ToString();
        PlayerPrefs.SetString("choiceSave", choiceSave);
    }


}
