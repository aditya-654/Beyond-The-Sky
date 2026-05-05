using UnityEngine;
using UnityEngine.Video;

public class PlayVideoOnTrigger : MonoBehaviour
{
    // Reference to the VideoPlayer
    private VideoPlayer videoPlayer;

    void Start()
    {
        // Get the VideoPlayer component
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Detect when the player enters the trigger area
    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Play the video
            if (!videoPlayer.isPlaying)
            {
                videoPlayer.Play();
            }
        }
    }
}
