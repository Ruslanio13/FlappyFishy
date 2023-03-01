using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [FormerlySerializedAs("Id")] [SerializeField] private int id;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button selectButton;
    [SerializeField] private TMP_Text selectButtonText;
    [SerializeField] private TMP_Text selectText;
    [SerializeField] private TMP_Text selectedText;
    [SerializeField] private Image skin;
    [SerializeField] private TMP_Text priceText;
    private int _price;
    public Item Item { get; private set; }

    public void OnEnable()
    { 
        buyButton.onClick.AddListener(BuyItem);
        selectButton.onClick.AddListener(SelectItem);
    }

    public void OnDisable()
    {
        buyButton.onClick.RemoveAllListeners();
        selectButton.onClick.RemoveAllListeners();
    }

    public void Initialize(Item item)
    {
        Item = item;
        id = item.Id;
        skin.sprite = item.Icon;
        _price = item.Price;
        priceText.text = _price.ToString();         
        buyButton.gameObject.SetActive(PlayerPrefs.GetInt(item.Type.ToString() + id) == 0);
        Debug.Log(item.Type.ToString() + id);
        selectButton.gameObject.SetActive(PlayerPrefs.GetInt(item.Type.ToString() + id) == 1);
    }
    
    private void BuyItem()
    {
        if (Wallet.Instance.Balance >= _price)
        {
            buyButton.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);

            Wallet.Instance.DecreaseBalance(_price);
            
            SkinManager.Instance.AddItem(id, Item);
            SkinManager.Instance.SelectItem(id, Item);
        }
    }

    private void SelectItem()
    {
        SkinManager.Instance.SelectItem(id, Item);
        Shop.instance.ShowSelectedItems();
    }
    public void UpdateSelection()
    {
        if (PlayerPrefs.GetInt("Selected" + Item.Type) == id)
            selectButtonText.text = selectedText.text;
        else
            selectButtonText.text = selectText.text;
    }
}
