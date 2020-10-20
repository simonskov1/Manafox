using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject MapTile;
    public List<GameObject> currentTiles = new List<GameObject>();
    int tileCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 6; i++)
        {
            GameObject tile = Instantiate(MapTile, new Vector3(0, -120, 500) * tileCount, Quaternion.identity);
            tileCount++;
            currentTiles.Add(tile);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReplaceTile(GameObject tileToReplace)
    {
        if(tileToReplace != null)
        {
        currentTiles.Remove(tileToReplace);
        Destroy(tileToReplace);
        GameObject tile = Instantiate(MapTile, new Vector3(0, -120, 500) * tileCount, Quaternion.identity);
        tileCount++;
        currentTiles.Add(tile);
        }
    }
}
