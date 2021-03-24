using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOnTriggered : MonoBehaviour
{
    [SerializeField]
    GameObject rewardParticle;

    public int pointsForCollision = 5;

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<LocalScoreSystem>().addPointsToScore(pointsForCollision);
        var rewardObj = Instantiate(rewardParticle, FindObjectOfType<Controller>().transform);
        Destroy(rewardObj, 3);
        Destroy(gameObject);
    }
}
