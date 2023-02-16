using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BirdSkinSelecter : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer hatSprite;
    [SerializeField] private SpriteRenderer moustacheSprite;
    [SerializeField] private SpriteRenderer glassesSprite;
    [SerializeField] private SpriteRenderer colorSprite;

    private Item _selectedHat;
    private Item _selectedGlasses;
    private Item _selectedMoustache;
    private Item _selectedColor;

    private void OnEnable()
    {
        SkinManager.Instance.onSkinChanged += PutOnSkin;
    }

    private void OnDisable()
    {
        SkinManager.Instance.onSkinChanged -= PutOnSkin;
    }
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = SkinManager.Instance.SelectedSkin.ActualSprite;
        PutOnSkin();
    }

    private void PutOnSkin()
    {
        InitializeSkin();
        FillSkin();
        AlighAccesoryPosition();
    }

    private void InitializeSkin()
    {
        _selectedHat = SkinManager.Instance.SelectedHat;
        _selectedGlasses = SkinManager.Instance.SelectedGlasses;
        _selectedMoustache = SkinManager.Instance.SelectedMoustache;
        _selectedColor = SkinManager.Instance.SelectedColor;
    }

    private void FillSkin()
    {
        hatSprite.sprite = _selectedHat.ActualSprite;
        moustacheSprite.sprite = _selectedMoustache.Icon;
        glassesSprite.sprite = _selectedGlasses.Icon;
        colorSprite.sprite = _selectedColor.Icon;
    }

    private void AlighAccesoryPosition()
    {
        hatSprite.transform.localPosition = new Vector2(_selectedHat.xPosition, _selectedHat.yPosition);
        hatSprite.transform.localScale = new Vector2(_selectedHat.xScale, _selectedHat.yScale);
    }
}
