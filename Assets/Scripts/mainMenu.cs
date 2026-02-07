using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }
}
