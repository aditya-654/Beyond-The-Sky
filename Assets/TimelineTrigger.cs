using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector timelineDirector; // Reference to the Playable Director

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the area
        if (other.CompareTag("Player"))
        {
            timelineDirector.Play(); // Play the Timeline
        }
    }
}
