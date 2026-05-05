using UnityEngine;
using UnityEngine.Playables; // Import Playables namespace

public class TimelineStarter : MonoBehaviour
{
    public PlayableDirector timeline; // Assign Timeline in Inspector

    void Start()
    {
        if (timeline != null)
        {
            timeline.Play(); // Starts the Timeline when game begins
        }
    }
}
