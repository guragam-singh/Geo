using UnityEngine;
using UnityEngine.SceneManagement; // Required for changing scenes

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;

    public void PlayGame()
    {
       
        SceneManager.LoadScene(1); 
        
    }
}
