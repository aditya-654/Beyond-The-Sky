using UnityEngine;
using UnityEngine.Video;

public class VideoTriggerManager2 : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer
    public VideoClip[] videoClips; // Array of VideoClips for different areas

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the Player has the "Player" tag
        {
            // Get the area ID based on the trigger's name or custom logic
            int areaIndex = GetAreaIndex(gameObject.name);

            if (areaIndex >= 0 && areaIndex < videoClips.Length)
            {
                PlayVideo(areaIndex);
            }
        }
    }

    private int GetAreaIndex(string areaName)
    {
        // Map trigger area names to video clip indices
        switch (areaName)
        {
            case "TriggerArea9": return 0;
            case "TriggerArea10": return 1;
            case "TriggerArea11": return 2;
            default: return -1; // Invalid area
        }
    }

    private void PlayVideo(int index)
    {
        videoPlayer.clip = videoClips[index];
        videoPlayer.Play();
    }
}
