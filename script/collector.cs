using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void PlayDiamondSound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
