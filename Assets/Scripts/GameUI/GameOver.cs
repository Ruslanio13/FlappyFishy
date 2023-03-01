using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Score scoreClass;
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text bestScore;

    private void OnEnable()
    {
        score.text = scoreClass.scoreInt.ToString();
        bestScore.text = PlayerPrefs.GetInt("best").ToString();
    }    
}
