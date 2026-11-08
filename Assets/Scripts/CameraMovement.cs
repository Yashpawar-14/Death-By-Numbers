
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Mouse Settings")]
    public float mouseSensitivity = 200f;

    [Header("Player Reference")]
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Camera looks up and down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Player rotates left and right
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
