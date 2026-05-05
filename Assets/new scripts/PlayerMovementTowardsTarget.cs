using UnityEngine;

public class PlayerMovementTowardsTarget : MonoBehaviour
{
    public Transform target; // Target object the player moves towards
    public float moveSpeed = 5f; // Movement speed

    private bool shouldMove = false;

    void Update()
    {
        if (shouldMove)
        {
            // Calculate the direction and move the player
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Optional: Stop moving if close enough to the target
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                shouldMove = false;
            }
        }
    }

    // Public method to start moving the player
    public void StartMoving()
    {
        shouldMove = true;
    }
}
