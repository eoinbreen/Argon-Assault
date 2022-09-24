using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
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
        float horizontalMovement = movement.ReadValue<Vector2>().x;
        float verticalMovement = movement.ReadValue<Vector2>().y;

        //float horizontalMovement = Input.GetAxis("Horizontal");
        print(horizontalMovement);
        //float verticalMovement = Input.GetAxis("Vertical");
        print(verticalMovement);
    }
}
