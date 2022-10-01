using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [Header("Input Settings")]
    [SerializeField] InputAction movement;
    [SerializeField] InputAction firing;
    
    [Header("General Setup Settings")]
    [Tooltip("How fast Ship Moves Up and Down")][SerializeField] float movementSpeed = 20f;
    [Tooltip("How far Ship Can Move Left and Right")] [SerializeField] float xRange = 10f;
    [Tooltip("How far Ship Can Move Up and Down")] [SerializeField] float yRange = 7f;
    
    [Header("Screen Position Based Tuning")]
    [Tooltip("Pitch Change in relation to Position")] [SerializeField] float PositionPitchFactor = -2f;
    [Tooltip("Yaw Change in relation to Position")] [SerializeField] float PositionYawFactor = 2f;
    
    [Header("Player Input Based Tuning")]
    [Tooltip("Pitch Change in relation to Movement")] [SerializeField] float movementPitchFactor = -15f;
    [Tooltip("Roll Change in relation to Movement")] [SerializeField] float MovementRollFactor = -20f;

    [Header("Laser Array")]
    [Tooltip ("Add all player Lasers here")][SerializeField] GameObject[] lasers;

    float xThrow, yThrow;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        movement.Enable();
        firing.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        firing.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation()
    {

        float pitchDueToPosition = transform.localPosition.y * PositionPitchFactor;
        float pitchDueToMovement = yThrow * movementPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToMovement;


        float yaw = transform.localPosition.x * PositionYawFactor; ;
        float roll = xThrow * MovementRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessMovement()
    {
        xThrow = movement.ReadValue<Vector2>().x;
        yThrow = movement.ReadValue<Vector2>().y;

        float xMovement = xThrow * Time.deltaTime;
        float yMovement = yThrow * Time.deltaTime;

        float rawXPos = transform.localPosition.x + (xMovement * movementSpeed);
        float rawYPos = transform.localPosition.y + (yMovement * movementSpeed);

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (firing.ReadValue<float>() > 0.5)
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

  
}
