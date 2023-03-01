using UnityEngine;
using TMPro;

public class FontCorrecter : MonoBehaviour
{
    [SerializeField] private TMP_Text[] texts;
    [SerializeField] private float delay;
    private void Start()
    {
        Invoke("CorrectFontSize", delay);  
    }

    private void CorrectFontSize()
    {
        float minFontSize = GetMinFontSize();
        SetFontSize(minFontSize);
    }

    private float GetMinFontSize()
    {
        float minSize = float.MaxValue;
        foreach(TMP_Text text in texts)
            if (minSize > text.fontSize)
                minSize = text.fontSize;
        return minSize;
    }

    private void SetFontSize(float size)
    {
        foreach (TMP_Text text in texts)
        {
            text.enableAutoSizing = false;
            text.fontSize = size;
        }
    }
}
