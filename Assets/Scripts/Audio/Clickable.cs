using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    public void ClickSound()
    {
        SoundManager.Instance.PlaySound(clip);
    }
}
