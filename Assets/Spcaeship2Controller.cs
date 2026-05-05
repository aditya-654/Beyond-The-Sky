using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class PlaneController : MonoBehaviour
{
    public XRLever thrustLever;  // Lever for controlling forward movement
    public XRLever targetLever;  // Lever for moving toward the target
    public XRKnob knob;          // Knob for controlling rotation
    public Transform target;     // Target object to move toward

    public float forwardSpeed = 10f;    // Speed of forward movement
    public float rotationSpeed = 100f; // Speed of rotation
    public float moveToTargetSpeed = 10f; // Speed of movement toward the target

    private float currentForwardSpeed;   // Current forward speed
    private float currentRotationSpeed;  // Current rotation speed

    void Update()
    {
        // Handle thrust lever for forward movement
        float thrustLeverValue = thrustLever.value ? 1f : 0f;
        currentForwardSpeed = forwardSpeed * thrustLeverValue;

        // Handle target lever for movement toward the target
        if (targetLever.value)
        {
            // Calculate direction toward the target
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            // Move the player toward the target
            transform.position += directionToTarget * moveToTargetSpeed * Time.deltaTime;

            // Optional: Rotate the player to face the target
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * moveToTargetSpeed);
        }
        else
        {
            // Apply forward movement only when the target lever is off
            Vector3 forwardMovement = transform.forward * currentForwardSpeed * Time.deltaTime;
            transform.position += forwardMovement;
        }

        // Handle rotation based on the knob's position
        currentRotationSpeed = rotationSpeed * Mathf.Lerp(-1f, 1f, knob.value);
        transform.Rotate(Vector3.up, currentRotationSpeed * Time.deltaTime);
    }
}
