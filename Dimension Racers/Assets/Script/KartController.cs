using UnityEngine;

public class KartController : MonoBehaviour
{
    float moveInput;
    float steerInput;

    public float acceleration = 25f;
    public float turnSpeed = 120f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        Move();
        Turn();
    }

    void Move()
    {
        rb.AddForce(transform.forward * moveInput * acceleration);
    }

    void Turn()
    {
        float turn = steerInput * turnSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turn, 0f));
    }
}
