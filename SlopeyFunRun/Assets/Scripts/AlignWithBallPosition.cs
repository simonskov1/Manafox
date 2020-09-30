using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignWithBallPosition : MonoBehaviour
{
    public Transform movementBall;
    
    void Update()
    {
        transform.position = movementBall.position;
    }
}
