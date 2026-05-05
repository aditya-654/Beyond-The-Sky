using UnityEngine;
using UnityEngine.SceneManagement; // Import Scene Management

public class SceneChangeTrigger : MonoBehaviour
{
    public string sceneToLoad; // Set the scene name in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            SceneManager.LoadScene(sceneToLoad); // Load the specified scene
        }
    }
}
