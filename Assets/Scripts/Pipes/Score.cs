using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private BirdEventHandler _birdEventHandler;
    [SerializeField] private TMP_Text _score;

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
    }
}
