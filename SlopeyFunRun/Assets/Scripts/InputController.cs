using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Vector3 movementV3;

    public Vector3 MovementV3
    {
        get
        {
            return movementV3;
        }
    }
    public bool Sprinting { get; private set; }
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sprinting = Input.GetButton("Sprint") ? true : false;
        movementV3 = GetMovement();
            
    }

    Vector3 GetMovement()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }



    
}
