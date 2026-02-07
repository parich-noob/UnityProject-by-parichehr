using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Life")]
    public int maxLife = 3;
    public int currentLife;

    [Header("Score")]
    public int score;

    [Header("Try System")]
    public int tries = 1;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        currentLife = maxLife;

        if (UIManager.Instance != null)
            UIManager.Instance.UpdateLifeUI(currentLife);
    }

    // ✅ متدی که EnemyBase لازم داره
    public void AddScore(int value)
    {
        score += value;

        if (UIManager.Instance != null)
            UIManager.Instance.UpdateScoreUI(score);
    }

    public void LoseLife()
    {
        currentLife--;

        if (UIManager.Instance != null)
            UIManager.Instance.UpdateLifeUI(currentLife);

        if (currentLife <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");

        if (UIManager.Instance != null)
            UIManager.Instance.ShowGameOver();
    }

    public void RestartTry()
    {
        tries++;
        currentLife = maxLife;

        if (UIManager.Instance != null)
            UIManager.Instance.UpdateLifeUI(currentLife);
    }
}
