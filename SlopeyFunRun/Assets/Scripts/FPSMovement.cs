using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController), typeof(MovementController), typeof(Rigidbody))]
public class FPSMovement : MonoBehaviour
{
    private InputController inputController;
    private MovementController movement;
    private bool frozen;


    public MovementController Movement
    {
        get
        {
            return movement;
        }
    }

    private void Awake()
    {
        inputController = GetComponent<InputController>();
        movement = GetComponent<MovementController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!isFrozen)
        {
            movement.Move(inputController.MovementV3);
        }
    }

    public bool isFrozen
    {
        get
        {
            return frozen;
        }
        set
        {
            frozen = value;
        }
    }
}
