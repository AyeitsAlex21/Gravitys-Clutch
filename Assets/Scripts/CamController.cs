using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamController : MonoBehaviour
{
    public float sensX, sensY;
    public Transform orientation;

    private float xRot = 0;
    private float yRot = 0;
    private InputAction lookAction;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        InputActionMap actionMap = GetComponent<PlayerInput>().actions.FindActionMap("Player");
        lookAction = actionMap.FindAction("Look");
        lookAction.performed += OnLookPerformed; // this will call on player moves mouse // has to be named preformed for some reason
    }

    private void OnLookPerformed(InputAction.CallbackContext context)
    {
        Vector2 movementVector = context.ReadValue<Vector2>();
        yRot += movementVector.x * sensX;
        xRot -= movementVector.y * sensY;

        xRot = Mathf.Clamp(xRot, -90f, 90f); // stops camera from going all the way around if look up or down

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.rotation = Quaternion.Euler(xRot, yRot, 0);


    }
}