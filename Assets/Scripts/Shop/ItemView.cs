using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [FormerlySerializedAs("Id")] [SerializeField] private int id;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button selectButton;
    [SerializeField] private Image skin;
    [SerializeField] private TMP_Text priceText;
    private int _price;
    public void OnEnable()
    { 
        buyButton.onClick.AddListener(BuySkin);
        selectButton.onClick.AddListener(SelectSkin);
    }

    public void OnDisable()
    {
        buyButton.onClick.RemoveAllListeners();
        selectButton.onClick.RemoveAllListeners();
    }

    public void Initialize(Item item)
    {
        id = item.Id;
        skin.sprite = item.Icon;
        _price = item.Price;
        priceText.text = _price.ToString();         
        buyButton.gameObject.SetActive(PlayerPrefs.GetInt("Skin" + id) == 0);
        selectButton.gameObject.SetActive(PlayerPrefs.GetInt("Skin" + id) == 1);
    }
    
    private void BuySkin()
    {
        if (Wallet.Instance.Balance >= _price)
        {
            buyButton.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);

            Wallet.Instance.DecreaseBalance(_price);
            
            SkinManager.Instance.AddSkin(id);
            SkinManager.Instance.SelectSkin(id);
        }
    }

    private void SelectSkin()
    {
        SkinManager.Instance.SelectSkin(id);
    }
}
