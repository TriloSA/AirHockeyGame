using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    public float speed = 5f; // Adjust movement speed

    private Vector2 moveInput;
    private Rigidbody rb;
    private PlayerInput controls;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new PlayerInput();
    }

    void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    void OnDisable()
    {
        controls.Player.Move.performed -= ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled -= ctx => moveInput = Vector2.zero;
        controls.Player.Disable();
    }

    void FixedUpdate()
    {
        // Convert 2D input to 3D movement
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y) * speed;

        // Apply movement with physics
        rb.linearVelocity = movement;
    }
}