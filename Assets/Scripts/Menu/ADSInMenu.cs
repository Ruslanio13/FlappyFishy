using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ADSInMenu : MonoBehaviour
{
    [SerializeField] private int rewardForAds;
    [SerializeField] private TMP_Text balance;
    [SerializeField] private Button adsButton;

    public void WatchAdsForReward(string rewardName)
    {
        YandexSDK.YaSDK.instance.ShowRewarded(rewardName);
        if (rewardName == "coin")
            Wallet.Instance.IncreaseBalance(rewardForAds);
        balance.text = PlayerPrefs.GetInt("balance").ToString();
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        adsButton.interactable = false;
        yield return new WaitForSeconds(1);
        adsButton.interactable = true;
    }
}
