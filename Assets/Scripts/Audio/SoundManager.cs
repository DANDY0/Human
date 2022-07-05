using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectsSource;
    [SerializeField] private AudioClip[] musicClip;

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
        }
    }

    public void PlaySound(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }
    
    public void PlayMusic()
    {
        musicSource.clip = musicClip[SceneManager.GetActiveScene().buildIndex];
        musicSource.enabled = false; 
        musicSource.enabled = true;//перезапуск AudioSource
        Debug.Log("Scene: " + SceneManager.GetActiveScene().buildIndex);
    }
    
    public void ToggleEffects()
    {
        effectsSource.mute = !effectsSource.mute;
    }
    
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
}