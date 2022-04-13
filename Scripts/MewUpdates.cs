using UnityEngine;


public class MewUpdates : MonoBehaviour
{
    [Header("Upgrade parameters")]
    [SerializeField] private double mewIncrease;
    [SerializeField] private double upgradeCost;
    [SerializeField] private double upgradeCostUp;

    private GameManager gameManager;
    private PlayScreen playScreen;

    public TMPro.TextMeshProUGUI mewIncreaseText;
    public TMPro.TextMeshProUGUI updateCostText;

    private void Start()
    {
        GetComponentScripts();
        CheckText();
    }

    private void GetComponentScripts()
    {
        gameManager = GetComponent<GameManager>();
        playScreen = GetComponent<PlayScreen>();
    }

    public void UpgradeMew ()
    {
        if (playScreen.totalMewAmount > upgradeCost)
        {
            playScreen.totalMewAmount -= upgradeCost;
            playScreen.mewForClick += mewIncrease;
            upgradeCost += upgradeCostUp;
            CheckText();
        }
    }

    private void CheckText()
    {
        mewIncreaseText.text = "+ " + GetValue(mewIncrease);
        mewIncreaseText.text = "+ " + GetValue(upgradeCost);
    }

    //gets beatiful converted values for the fields ingame
    public string GetValue(double value)
    {
        string convertedValue = "broken";
        double roundedValue = Mathf.RoundToInt((float)value);
        if (roundedValue >= 1000000000000)
        {
            convertedValue = (roundedValue / 1000000000000).ToString() + "t";
        }
        else if (roundedValue >= 1000000000)
        {
            convertedValue = (roundedValue / 1000000000).ToString() + "b";
        }
        else if (roundedValue >= 1000000)
        {
            convertedValue = (roundedValue / 1000000).ToString() + "kk";
        }
        else if (roundedValue >= 1000)
        {
            convertedValue = (roundedValue / 1000).ToString() + "k";
        }
        else if (roundedValue >= 1)
        {
            convertedValue = (roundedValue / 1).ToString();
        }
        else Debug.LogError("The number is too big!!!");
        return convertedValue;
    }



}
