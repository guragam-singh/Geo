using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.TransitionToGameplay(1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Game Exited");
        Application.Quit();
    }
}
