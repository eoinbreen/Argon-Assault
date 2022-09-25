using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float movementSpeed = 20f;
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
        float xMovement = movement.ReadValue<Vector2>().x * Time.deltaTime;
        float yMovement = movement.ReadValue<Vector2>().y * Time.deltaTime;

        float newXPos = transform.localPosition.x + (xMovement * movementSpeed);
        float newYPos = transform.localPosition.y + (yMovement * movementSpeed);
        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }
}
