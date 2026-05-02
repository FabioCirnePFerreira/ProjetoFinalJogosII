using UnityEngine;
using UnityEngine.InputSystem;

public class KartController : MonoBehaviour
{
    public float acceleration = 25f;
    public float maxSpeed = 30f;
    public float turnSpeed = 120f;

    private Rigidbody rb;

    private KartInputActions input;
    private Vector2 moveInput;

    void Awake()
    {
        input = new KartInputActions();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveInput = input.Player.Move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Move();
        Turn();
    }

    void Move()
    {
        rb.AddForce(transform.forward * moveInput.y * acceleration, ForceMode.Acceleration);
    }

    void Turn()
    {
        float turn = moveInput.x * turnSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turn, 0f));
    }
}
