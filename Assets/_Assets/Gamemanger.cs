using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required for the Slider

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Objects")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform finishLine;

    [Header("UI Elements")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Slider progressSlider;

    private float startX;
    private float totalDistance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        // Calculate the total length of the level
        if (player != null && finishLine != null)
        {
            startX = player.position.x;
            totalDistance = finishLine.position.x - startX;
        }
    }

    private void Update()
    {
        // Update the slider value every frame based on player position
        if (player != null && finishLine != null && progressSlider != null)
        {
            float currentDistance = player.position.x - startX;
            // Clamp01 ensures the value stays between 0 and 1
            progressSlider.value = Mathf.Clamp01(currentDistance / totalDistance);
        }
    }

    public void TriggerGameOver()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void TriggerLevelComplete()
    {
        Debug.Log("You Won!");
        if (winPanel != null) winPanel.SetActive(true);
        Time.timeScale = 0f; // Freeze game
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
