using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BirdSkinSelecter : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = SkinManager.Instance.SelectedSkin;
    }

}
