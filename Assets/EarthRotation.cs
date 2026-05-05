using UnityEngine;

public class EarthRotation : MonoBehaviour
{
    public float rotationSpeed = 15f; // Speed of Earth's rotation (degrees per second)

    void Update()
    {
        // Rotate the Earth around its Y-axis (self-rotation)
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
