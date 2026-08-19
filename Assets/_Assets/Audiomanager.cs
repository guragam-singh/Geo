using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource menuSource;
    [SerializeField] private AudioSource gameplaySource;

    [Header("Settings")]
    [SerializeField] private float fadeDuration = 2.0f; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void TransitionToGameplay(int nextSceneIndex)
    {
        StartCoroutine(FadeTrackRoutine(nextSceneIndex));
    }

    private IEnumerator FadeTrackRoutine(int nextSceneIndex)
    {
        float time = 0;
        float startMenuVolume = menuSource.volume;

        if (gameplaySource != null)
        {
            gameplaySource.volume = 0;
            gameplaySource.Play();
        }

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float progress = time / fadeDuration;

            if (menuSource != null) 
                menuSource.volume = Mathf.Lerp(startMenuVolume, 0, progress);
            
            if (gameplaySource != null) 
                gameplaySource.volume = Mathf.Lerp(0, 1f, progress);

            yield return null; 
        }

        
        if (menuSource != null)
        {
            menuSource.Stop();
            menuSource.volume = startMenuVolume; 
        }
        if (gameplaySource != null)
        {
            gameplaySource.volume = 1f;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
