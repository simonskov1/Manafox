using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOnTriggered : MonoBehaviour
{
    public int pointsForCollision = 5;

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<LocalScoreSystem>().addPointsToScore(pointsForCollision);
    }
}
