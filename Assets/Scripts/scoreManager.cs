using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public static scoreManager Instance;

    public int score;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UIManager.Instance.UpdateScoreUI(score);
    }
}
