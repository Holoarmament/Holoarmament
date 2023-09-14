using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensitivity = 2f; // Mouse sensitivity
    public float smoothing = 1f; // Mouse smoothing

    private Vector2 smoothMouseDelta = Vector2.zero;
    private Vector2 currentMouseDelta = Vector2.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Hide the cursor
    }

    private void Update()
    {
        // Get mouse input
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        // Apply smoothing
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothMouseDelta.x = Mathf.Lerp(smoothMouseDelta.x, mouseDelta.x, 1f / smoothing);
        smoothMouseDelta.y = Mathf.Lerp(smoothMouseDelta.y, mouseDelta.y, 1f / smoothing);

        // Update camera rotation based on mouse input
        transform.localRotation *= Quaternion.Euler(-smoothMouseDelta.y, 0, 0);
        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, 0); // Lock camera's Z rotation
        transform.parent.localRotation *= Quaternion.Euler(0, smoothMouseDelta.x, 0);
    }
}