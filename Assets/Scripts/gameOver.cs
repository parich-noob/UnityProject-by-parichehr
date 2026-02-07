using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
