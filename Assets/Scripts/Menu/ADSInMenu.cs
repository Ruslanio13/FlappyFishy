using UnityEngine;
using UnityEngine.UI;
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
            Wallet.Instance.IncreaseBalance(rewardForAds);
    }
}
