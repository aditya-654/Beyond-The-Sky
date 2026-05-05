using UnityEngine;
using UnityEngine.Video;

public class VideoTriggerManager : MonoBehaviour
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
            case "TriggerArea1": return 0;
            case "TriggerArea2": return 1;
            case "TriggerArea3": return 2;
            case "TriggerArea4": return 3;
            case "TriggerArea5": return 4;
            case "TriggerArea6": return 5;
            case "TriggerArea7": return 6;
            case "TriggerArea8": return 7;
            default: return -1; // Invalid area
        }
    }

    private void PlayVideo(int index)
    {
        videoPlayer.clip = videoClips[index];
        videoPlayer.Play();
    }
}

