using UnityEngine;
using UnityEngine.UI;

public class ToggleAudio : MonoBehaviour
{
    [SerializeField] private bool toggleMusic, toggleEffects;
    [SerializeField] private Image imgMusic, imgEffects;
    public void Toggle()
    {
        if (toggleEffects)
        { SoundManager.Instance.ToggleEffects(); 
            imgEffects.enabled = !imgEffects.enabled;
        }

        if (toggleMusic)
        {
            SoundManager.Instance.ToggleMusic();
            
            imgMusic.enabled = !imgMusic.enabled;
        }
    }
    
}