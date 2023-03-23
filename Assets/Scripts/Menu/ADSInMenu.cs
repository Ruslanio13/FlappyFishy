using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YG;

public class ADSInMenu : MonoBehaviour
{
    [SerializeField] private Button adsButton;
    [SerializeField] private int rewardForAds;
    [SerializeField] private int adID;

    private void Start()
    {
        adsButton.onClick.AddListener(() => YandexGame.Instance._RewardedShow(rewardForAds));
        adsButton.onClick.AddListener(() => Rewarded(adID));
    }

    public void Rewarded(int id)
    {
        if (id == adID)
            StartCoroutine(DelayedReward());
    }

    private IEnumerator DelayedReward()
    {
        adsButton.interactable = false;
        Wallet.Instance.IncreaseBalance(rewardForAds);
        yield return new WaitForSeconds(3);
        adsButton.interactable = true;
    }
}
