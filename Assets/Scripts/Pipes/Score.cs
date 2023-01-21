using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private BirdEventHandler _birdEventHandler;
    [SerializeField] private TMP_Text _score;
    public int scoreInt { get; private set; }

    private void OnEnable()
    {
        _birdEventHandler.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _birdEventHandler.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
        scoreInt = score;
        if (score > PlayerPrefs.GetInt("best"))
            PlayerPrefs.SetInt("best", score);
    }
}
