using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newTileTrigger : MonoBehaviour
{
    public TileSpawner spawner;

    private void Awake()
    {
        spawner = FindObjectOfType<TileSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        spawner.ReplaceTile(this.gameObject);
    }
}
