using UnityEngine;

public class PlayAudioOnEntry : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            if (!audioSource.isPlaying) // Ensure audio doesn't overlap
            {
                audioSource.Play();
            }
        }
    }
}
