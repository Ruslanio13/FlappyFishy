using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BirdSkinSelecter : MonoBehaviour
{
	
    private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer hatSprite;
    [SerializeField] private SpriteRenderer moustacheSprite;
    [SerializeField] private SpriteRenderer glassesSprite;

    private Item _selectedHat;
    private Item _selectedGlasses;
    private Item _selectedMoustache;
    void Start()
    {
        _selectedHat = SkinManager.Instance.SelectedHat;
        _selectedGlasses = SkinManager.Instance.SelectedGlasses;
        _selectedMoustache = SkinManager.Instance.SelectedMoustache;
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = SkinManager.Instance.SelectedSkin.ActualSprite;

        hatSprite.sprite = _selectedHat.ActualSprite;
        moustacheSprite.sprite = _selectedMoustache.Icon;
        glassesSprite.sprite = _selectedGlasses.Icon;
        AlighAccesoryPosition();
    }

    private void AlighAccesoryPosition()
    {
        hatSprite.transform.position = new Vector2(_selectedHat.xPosition, _selectedHat.yPosition);
        hatSprite.transform.localScale = new Vector2(_selectedHat.xScale, _selectedHat.yScale);
    }
}
