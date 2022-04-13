using UnityEngine;
using System;

public class MewUpgrade : MonoBehaviour
{
    //ƒŒœ»ÿ» ◊“Œ¡€ œ–» Õ”À≈¬ŒÃ «Õ¿◊≈Õ»» œŒÀ≈… «¿–¿¡Œ“ ¿ ¬€—¬≈◊»¬¿À—ﬂ œ–Œ—“Œ ÕŒÀ‹

    [SerializeField] private string buttonName;

    [Header("Increase parameters")]
    [SerializeField] private double mewForClickIncrease;
    [SerializeField] private double mewOverTimeIncrease;

    [Header("Upgrade parameters")]
    [SerializeField] private double upgradeCost;
    [SerializeField] private double upgradeCostMultiplier = 1.075;

    [Header("Multipliers")]
    [SerializeField] private double clickMultiplier;
    [SerializeField] private double overTimeMultiplier;

    private bool isForClickPercentageIncrease;
    private bool isOverTimePercentageIncrease;

    [Header("PlayerPrefs key")]
    [SerializeField] private string updateCostPrefs;

    private PlayScreen playScreen;

    [Header("Text links")]
    [SerializeField] private TMPro.TextMeshProUGUI buttonNameText;
    [SerializeField] private TMPro.TextMeshProUGUI mewForClickIncreaseText;
    [SerializeField] private TMPro.TextMeshProUGUI mewOverTimeIncreaseText;
    [SerializeField] private TMPro.TextMeshProUGUI updateCostText;

    public void Start()
    {
        GetScriptComponents();
        LoadData();
        CheckIsPercentIncrease();
        CheckText();
    } 

    //just to make Start look beatiful
    private void GetScriptComponents ()
    {
        playScreen = GetComponent<PlayScreen>();
    }

    //Upgrade mew amount per click and per sec
    public void UpgradeMew()
    {
        if (playScreen.totalMewAmount > upgradeCost)
        {
            playScreen.totalMewAmount -= upgradeCost;

            playScreen.mewForClick += mewForClickIncrease;
            playScreen.mewOverTime += mewOverTimeIncrease;

            playScreen.multiplierForClick += clickMultiplier;
            playScreen.multiplierOverTime += overTimeMultiplier;

            upgradeCost *= upgradeCostMultiplier;
            CheckText();
        }
    }
    //check is it percent or number increase
    private void CheckIsPercentIncrease ()
    {
        if (mewForClickIncrease > 0)
        {
            isForClickPercentageIncrease = false;
        }
        else isForClickPercentageIncrease = true;
        if (mewOverTimeIncrease > 0)
        {
            isOverTimePercentageIncrease = false;
        }
        else isOverTimePercentageIncrease = true;
    }
    //check text on the button
    private void CheckText()
    {
        buttonNameText.text = buttonName;

        if (isForClickPercentageIncrease == false)
        {
            mewForClickIncreaseText.text = "+" + playScreen.GetConvertedValue(mewForClickIncrease);
        } 
        else
        {
            mewForClickIncreaseText.text = "+" + clickMultiplier * 100 + "%";  
        }
        updateCostText.text = playScreen.GetConvertedValue(upgradeCost);
        if (isOverTimePercentageIncrease == false)
        {
            mewOverTimeIncreaseText.text = "+" + playScreen.GetConvertedValue(mewOverTimeIncrease);
        }
        else
        {
            mewOverTimeIncreaseText.text = "+" + overTimeMultiplier * 100 + "%";
        }

    }

    public void SaveData()
    {
        PlayerPrefs.SetString(updateCostPrefs, upgradeCost.ToString());
    }

    public void LoadData ()
    {
        string cost = PlayerPrefs.GetString(updateCostPrefs, upgradeCost.ToString());
        double _cost = Convert.ToDouble(cost);
        upgradeCost = _cost;
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
