
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private InputActionReference moveAction;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
        moveAction.action.Enable();
    }

    void OnDisable()
    {
        moveAction.action.Disable();
    }

    void Update()
    {
        // Get movement input
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        Vector3 move = transform.right * input.x
                     + transform.forward * input.y;

        move = Vector3.ClampMagnitude(move, 1f);

        // Apply gravity
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        // Combine horizontal and vertical movement
        Vector3 finalMove = move * speed + velocity;

        controller.Move(finalMove * Time.deltaTime);
    }
}
