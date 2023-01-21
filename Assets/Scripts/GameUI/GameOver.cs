using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameoverWindow;
    [SerializeField] private GameObject[] gameplayElements;
    [SerializeField] private BirdEventHandler eventHandler;
    [SerializeField] private Score scoreClass;
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text bestScore;

    private void Start()
    {
        eventHandler.PlayerDeath += ShowWindow;
        eventHandler.GameRestart += HideWindow;
    }

    private void ShowWindow()
    {
        gameoverWindow.SetActive(true);
        foreach (var item in gameplayElements)
            item.SetActive(false);
        score.text = "score:\n" + scoreClass.scoreInt.ToString();
        bestScore.text = "best:\n" + PlayerPrefs.GetInt("best").ToString();
    }

    private void HideWindow()
    {
        gameoverWindow.SetActive(false);
        foreach (var item in gameplayElements)
            item.SetActive(true);
    }
}
