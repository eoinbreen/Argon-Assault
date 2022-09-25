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

        //Y Clamp (-8f, 11f) X Clamp (-16f, 16f)
        float xMovement = movement.ReadValue<Vector2>().x * Time.deltaTime;
        float yMovement = movement.ReadValue<Vector2>().y * Time.deltaTime;

        float rawXPos = transform.localPosition.x + (xMovement * movementSpeed);
        float rawYPos = transform.localPosition.y + (yMovement * movementSpeed);

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
