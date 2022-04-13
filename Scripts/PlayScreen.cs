using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayScreen : MonoBehaviour
{
    [Header("Mew parameters")]
    public double mewForClick = 1;
    public double mewOverTime = 1;
    public double multiplierForClick;
    public double multiplierOverTime;

    //final number to calculate
    private double bonusForClick;
    private double bonusOverTime;
    private double finalForClick;
    private double finalOverTime;

    [Header("Total mew numbers")]
    public double totalMewAmount;
    public double totalMewOverTime;

    private float mewTimerCountdown = 1f;

    [Header("Text related")]
    [SerializeField] private TMPro.TextMeshProUGUI mewCounter;
    [SerializeField] private TMPro.TextMeshProUGUI mewForClickText;
    [SerializeField] private TMPro.TextMeshProUGUI mewOverTimeText;

    DateTime currentDate;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PoopOverTime());
        CountTimeSinceQuit();
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        CountPoop();
    }

    public void OnButtonClick ()
    {
        bonusForClick = mewForClick * multiplierForClick;
        finalForClick = mewForClick + bonusForClick;

        totalMewAmount += finalForClick;
        totalMewOverTime += finalForClick;

    }

    //Increase total poop every n second by poopOverTime
    IEnumerator PoopOverTime ()
    {
        while (this.enabled)
        {
            bonusOverTime = mewOverTime * multiplierOverTime;
            finalOverTime = mewOverTime + bonusOverTime;
            totalMewAmount += (mewOverTime + mewOverTime * multiplierOverTime);
            totalMewOverTime += finalOverTime;
            yield return new WaitForSeconds(mewTimerCountdown);
        }
    }

    public void CountTimeSinceQuit()
    {
        //Store the current time when it starts
        currentDate = DateTime.Now;

        //Grab the old time from the player prefs as a long
        long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));

        //Convert the old time from binary to a DataTime variable
        DateTime oldDate = DateTime.FromBinary(temp);
        print("oldDate: " + oldDate);

        //Use the Subtract method and store the result as a timespan variable
        TimeSpan difference = currentDate.Subtract(oldDate);
        print("Difference: " + difference);
        TimeSpan timeElapsed = currentDate - oldDate;
        double secondsFromLastBoot = timeElapsed.TotalSeconds;
        totalMewAmount += secondsFromLastBoot * mewOverTime;

        //Debuggin'
        Debug.Log("Time after quit: " + timeElapsed);
        Debug.Log("Seconds after quit: " + secondsFromLastBoot);
        
    }

    private void OnApplicationQuit()
    {
        //Savee the current system time as a string in the player prefs class
        PlayerPrefs.SetString("sysString", DateTime.Now.ToBinary().ToString());
        print("Saving this date to prefs: " + DateTime.Now);
        SaveData();
    }

    public void SaveData()
    {
        //save total poop amount to PlayerPrefs
        PlayerPrefs.SetString("amounts", totalMewAmount.ToString());
        //save poop for click and over time to player prefs
        PlayerPrefs.SetString("forClick", mewForClick.ToString());
        PlayerPrefs.SetString("overTime", mewOverTime.ToString());
        PlayerPrefs.SetString("bonusForClick", multiplierForClick.ToString());
        PlayerPrefs.SetString("bonusOverTime", multiplierOverTime.ToString());
    }

    public void LoadData()
    {
        //loading total poop amount
        string total = PlayerPrefs.GetString("amounts", totalMewAmount.ToString());
        double _total = Convert.ToDouble(total);
        totalMewAmount = _total;
        //loading poop for click amount
        string forClick = PlayerPrefs.GetString("forClick", mewForClick.ToString());
        double _forClick = Convert.ToDouble(forClick);
        mewForClick = _forClick;
        //loading poop over time amount
        string overTime = PlayerPrefs.GetString("overTime", mewOverTime.ToString());
        double _overTime = Convert.ToDouble(overTime);
        mewOverTime = _overTime;
    }

    public void CountPoop()
    {
        mewCounter.text = "Current mew is " + GetConvertedValue(totalMewAmount);
        mewForClickText.text = GetConvertedValue(finalForClick);
        mewOverTimeText.text = GetConvertedValue(finalOverTime);
    }

    public string GetConvertedValue(double value)
    {
        string convertedValue = "broken";
        if (value >=      1000000000000000000)
        {
            convertedValue = (value / 1000000000000000).ToString("#.##") + "you are gigachad";
        }
        else if (value >= 1000000000000000)
        {
            convertedValue = (value / 1000000000000000).ToString("#.##") + "stop";
        }
        else if (value >= 1000000000000)
        {
            convertedValue = (value / 1000000000000).ToString("#.##") + "t";
        }
        else if (value >= 1000000000)
        {
            convertedValue = (value / 1000000000).ToString("#.##") + "b";
        }
        else if (value >= 1000000)
        {
            convertedValue = (value / 1000000).ToString("#.##") + "kk";
        }
        else if (value >= 1000)
        {
            convertedValue = (value / 1000).ToString("#.##") + "k";
        }
        else if (value >= 0)
        {
            convertedValue = (value / 1).ToString("#.##") + "";
        }
        else Debug.LogError("The number is too big!!!");
        return convertedValue;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
