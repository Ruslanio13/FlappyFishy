using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Button[] skinButtons;
    [SerializeField] private Sprite[] skins;
    [SerializeField] private SpriteRenderer pickedSkin;

    private void OnEnable()
    {
        skinButtons[0].onClick.AddListener(() => ChangeSkin(0));
        skinButtons[1].onClick.AddListener(() => ChangeSkin(1));
        skinButtons[2].onClick.AddListener(() => ChangeSkin(2));
        skinButtons[3].onClick.AddListener(() => ChangeSkin(3));
        skinButtons[4].onClick.AddListener(() => ChangeSkin(4));
        skinButtons[5].onClick.AddListener(() => ChangeSkin(5));

        //акърэ ъ уси гмюер онвелс щрю акъчдсцю ме пюанрюер вепег жхйк

        //for (int i = 0; i < skinButtons.Length; i++)
        //{
        //    skinButtons[i].onClick.AddListener(() => ChangeSkin(i));
        //}
        //нм бяел онвелс - рн дюер хмдейя 6 ве гю усимъ
    }

    private void OnDisable()
    {
        for (int i = 0; i < skinButtons.Length; i++)
            skinButtons[i].onClick.RemoveListener(() => ChangeSkin(i));

    }

    private void ChangeSkin(int skinNumber)
    {
        pickedSkin.sprite = skins[skinNumber];
    }
}
