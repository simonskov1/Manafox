using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2f;
    [SerializeField]
    private float m_MovementSmoothing = .05f;

    Rigidbody rb;
    private Vector3 m_Velocity = Vector3.zero;


    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
            Vector3 targetVelocity = (transform.TransformDirection(new Vector3(direction.x * movementSpeed, 0, direction.z * movementSpeed)) + new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z));
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
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
