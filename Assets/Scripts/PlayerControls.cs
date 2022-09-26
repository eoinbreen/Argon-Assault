using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float movementSpeed = 20f;

    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;

    [SerializeField] float PositionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float PositionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessRotation();
    }

    void ProcessRotation()
    {

        float pitchDueToPosition = transform.localPosition.y * PositionPitchFactor;
        float pitchDueToMovement = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToMovement;


        float yaw = transform.localPosition.x * PositionYawFactor; ;
        float roll = xThrow * controlRollFactor;

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
}
