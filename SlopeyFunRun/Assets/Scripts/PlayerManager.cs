using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController), typeof(MovementController))]
public class PlayerManager : MonoBehaviour
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
            movement.Walk(inputController.MovementV3, inputController.Sprinting);
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
