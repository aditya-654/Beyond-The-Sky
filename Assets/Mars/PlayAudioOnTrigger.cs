using UnityEngine;

public class PlayAudioOnTrigger : MonoBehaviour
{
    // Reference to the AudioSource
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // Detect when the player enters the trigger area
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Play the audio clip
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
