using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newTileTrigger : MonoBehaviour
{
    public int pointsForPassingTile = 5;
    private TileSpawner spawner;
    private LocalScoreSystem localScore;


    private void Awake()
    {
        spawner = FindObjectOfType<TileSpawner>();
        localScore = FindObjectOfType<LocalScoreSystem>();
    }

    private void OnTriggerExit(Collider other)
    {
        spawner.ReplaceTile(this.gameObject);
        localScore.addPointsToScore(pointsForPassingTile);
    }
}
