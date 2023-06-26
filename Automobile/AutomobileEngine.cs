using UnityEngine;

public class AutomobileEngine : MonoBehaviour
{
    [SerializeField] private float enginePower = 5f;

    [SerializeField] private Transform centerOfMass;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private Transform[] forwardWheels;
    [SerializeField] private WheelCollider[] allWheels;

    private Vector2 moveVector = Vector2.zero;

    public void Move(Vector2 value)
	{
        moveVector = value;
    }

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        if (centerOfMass == null)
            centerOfMass = transform;
    }

	private void FixedUpdate()
	{
        rb.centerOfMass = transform.InverseTransformPoint(centerOfMass.position);

        foreach (Transform wheel in forwardWheels)
        {
            wheel.rotation = transform.rotation;
			wheel.Rotate(0.0f, moveVector.x * 20f, 0.0f, Space.Self);
        }

        if (moveVector == Vector2.zero)
            return;

        foreach (WheelCollider wheel in allWheels)
		{
            if(wheel.isGrounded)
            {
                rb.AddForce(enginePower * moveVector.y * wheel.transform.forward);
            }
        }


    }
}
