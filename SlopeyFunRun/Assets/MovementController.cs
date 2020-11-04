using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Transform BodyAxis;
    Rigidbody rb;
    public float forceAmount = 1;

    [SerializeField]
    private Animator animator;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        animator.SetBool("isTurningLeft", false);
        animator.SetBool("isTurningRight", false);

        Vector3 direction = new Vector3(BodyAxis.right.x, 0, BodyAxis.right.z);

        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-direction * forceAmount, ForceMode.Acceleration);
            animator.SetBool("isTurningLeft", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(direction * forceAmount, ForceMode.Acceleration);
            animator.SetBool("isTurningRight", true);
        }
    }
}
