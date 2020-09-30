using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Transform BodyAxis;
    Rigidbody rb;
    public float forceAmount = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 direction = new Vector3(BodyAxis.right.x, 0, BodyAxis.right.z);

        if(Input.GetKey(KeyCode.A))
            rb.AddForce(-direction * forceAmount, ForceMode.Acceleration);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(direction * forceAmount, ForceMode.Acceleration);
    }
}
