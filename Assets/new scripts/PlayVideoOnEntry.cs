using UnityEngine;
using UnityEngine.Video;

public class PlayVideoOnEntry : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the Video Player component

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            videoPlayer.Play(); // Play the video
        }
    }
}

