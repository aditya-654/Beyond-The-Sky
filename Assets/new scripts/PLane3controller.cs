using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class PlaneController2 : MonoBehaviour
{
    public XRLever thrustLever;        // Lever for controlling forward movement
    public XRKnob knob;                // Knob for controlling rotation
    public XRLever[] targetLevers;     // Array of levers for moving toward targets
    public XRLever revolveLever;       // Lever for controlling revolution around the target
    public XRLever boostLever;         // Lever for boosting speed
    public Transform[] targets;        // Array of target objects to move toward

    public float forwardSpeed = 10f;    // Speed of forward movement
    public float boostMultiplier = 2f; // Multiplier for boost speed
    public float rotationSpeed = 100f; // Speed of rotation
    public float moveToTargetSpeed = 10f; // Speed of movement toward the target
    public float revolveSpeed = 50f;   // Speed of revolution around the target

    private float currentForwardSpeed;   // Current forward speed
    private float currentRotationSpeed;  // Current rotation speed
    private Transform currentTarget;     // Current target being moved toward or revolved around
    private bool isRevolving = false;    // Whether the player is revolving around a target
    private bool isBoosting = false;     // Whether the boost lever is active

    void Update()
    {
        // Check if the boost lever is active
        isBoosting = boostLever.value;

        // Handle thrust lever for forward movement
        float thrustLeverValue = thrustLever.value ? 1f : 0f;

        // Apply boost multiplier if boosting
        currentForwardSpeed = forwardSpeed * thrustLeverValue * (isBoosting ? boostMultiplier : 1f);

        bool isMovingToTarget = false;

        // Handle movement toward targets using the levers
        for (int i = 0; i < targetLevers.Length; i++)
        {
            if (targetLevers[i].value)
            {
                isMovingToTarget = true;
                currentTarget = targets[i];

                if (!isRevolving)
                {
                    MoveTowardsTarget(currentTarget);
                }
                break; // Prioritize the first active lever
            }
        }

        // If the revolve lever is active, start revolving around the current target
        if (revolveLever.value && currentTarget != null)
        {
            isRevolving = true;
            RevolveAroundTarget(currentTarget);
        }
        else if (!isMovingToTarget) // Allow forward movement if no levers are active
        {
            isRevolving = false;
            Vector3 forwardMovement = transform.forward * currentForwardSpeed * Time.deltaTime;
            transform.position += forwardMovement;
        }

        // Handle rotation based on the knob's position
        currentRotationSpeed = rotationSpeed * Mathf.Lerp(-1f, 1f, knob.value);
        transform.Rotate(Vector3.up, currentRotationSpeed * Time.deltaTime);
    }

    private void MoveTowardsTarget(Transform target)
    {
        // Calculate direction to the target
        Vector3 directionToTarget = (target.position - transform.position).normalized;

        // Move toward the target
        float speed = isBoosting ? moveToTargetSpeed * boostMultiplier : moveToTargetSpeed;
        transform.position += directionToTarget * speed * Time.deltaTime;

        // Rotate to face the target
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * moveToTargetSpeed);
    }

    private void RevolveAroundTarget(Transform target)
    {
        // Revolve around the target
        float speed = isBoosting ? revolveSpeed * boostMultiplier : revolveSpeed;
        transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);

        // Keep the player facing the target while revolving
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * revolveSpeed);
    }
}


