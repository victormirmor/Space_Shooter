using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // 2.1. Referencias de UI
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    void Start()
    {
        restartText.text = "";
        gameOverText.text = "";
    }

    public void UpdateScoreDisplay(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void ShowGameOver(string message)
    {
        gameOverText.text = "Game Over!";
        restartText.text = message;
    }
}