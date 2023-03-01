using TMPro;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    [SerializeField] private TMP_Text bestScore;
    void Start()
    {
        bestScore.text = PlayerPrefs.GetInt("best").ToString();
    }
}
