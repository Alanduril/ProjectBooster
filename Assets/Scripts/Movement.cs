using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotate;
    Rigidbody rb;
    [SerializeField] float thrustStrength = 1f;
    [SerializeField] float rotateStrength = 1f;

    void OnEnable()
    {
        thrust.Enable();
        rotate.Enable();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        ProcessThrust();
        ProccesRotation();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }
    void ProccesRotation()
    {
        float rotationInput = rotate.ReadValue<float>();
        if (rotationInput > 0)
        {
            ApplyRotation(-rotateStrength);
        }
        else if (rotationInput < 0)
        {
            ApplyRotation(rotateStrength);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
    }
}
