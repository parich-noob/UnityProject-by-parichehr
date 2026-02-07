using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI scoreText;
    public GameObject[] hearts;
    public GameObject gameOverPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateScoreUI(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateLifeUI(int life)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < life);
        }
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
