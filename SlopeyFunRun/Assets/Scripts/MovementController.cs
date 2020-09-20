using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2f;
    [SerializeField]
    private float SprintModifier = 1.5f;
    [SerializeField]
    private float m_MovementSmoothing = .05f;

    Rigidbody rb;
    private Vector3 m_Velocity = Vector3.zero;

    bool isWalking;

    public bool IsWalking
    {
        get
        {
            return isWalking;
        }
    }

    public bool IsSprinting { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Walk(Vector3 direction, bool isSprinting)
    {
        IsSprinting = isSprinting;
        //transform.TransformDirection: Transforms the direction x, y, z from local space to World space. takes objects local vector.foward, and "rotates it" to match world vector.forward. rb.velocity is a world space property, so we need to convert to local direction to a world space direction so the rb.velocity will be accurate.
        if (!IsSprinting)
        {
            Vector3 targetVelocity = (transform.TransformDirection(new Vector3(direction.x * movementSpeed, 0, direction.z * movementSpeed)) + new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z));
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }
        else
        {
            Vector3 targetVelocity = (transform.TransformDirection(new Vector3(direction.x * movementSpeed * SprintModifier, 0, direction.z * movementSpeed * SprintModifier)) + new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z));
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }



        if (direction == Vector3.zero && isWalking)
            isWalking = false;
        else if(!isWalking && direction != Vector3.zero)
            isWalking = true;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
