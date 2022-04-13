using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    [Header("Statistics text links")]
    [SerializeField] private TMPro.TextMeshProUGUI totalMewOverTimeText;
    [Header("")]
    [SerializeField] private TMPro.TextMeshProUGUI mewForClickText;
    [SerializeField] private TMPro.TextMeshProUGUI bonusForClickText;
    [Header("")]
    [SerializeField] private TMPro.TextMeshProUGUI mewOverTimeText;
    [SerializeField] private TMPro.TextMeshProUGUI bonusOverTimeText;

    [SerializeField] private PlayScreen playScreen;

    private void Update()
    {
        CheckText();
    }

    private void CheckText()
    {
        totalMewOverTimeText.text = "Total mew over time is " + playScreen.GetConvertedValue(playScreen.totalMewOverTime);

        mewForClickText.text = "Mew for click is " + playScreen.GetConvertedValue(playScreen.mewForClick);
        bonusForClickText.text = "Bonus for click is " + playScreen.mewForClick * playScreen.multiplierForClick;

        mewOverTimeText.text = "Mew over time is " + playScreen.mewOverTime;
        bonusOverTimeText.text = "Bonus over time is " + playScreen.mewOverTime * playScreen.multiplierOverTime;
    }
}
