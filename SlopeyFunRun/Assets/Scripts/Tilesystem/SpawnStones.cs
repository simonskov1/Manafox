using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStones : MonoBehaviour
{
    public static int StonesToSpawn = 10;
    MeshCollider meshCollider;
    List<Ray> rays = new List<Ray>();
    int maxRayDistance = 200;
    public LayerMask layerMask;
    public GameObject rockPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        meshCollider = GetComponent<MeshCollider>();

    }

    private void Start()
    {
        SpawnRocksAtRandomPointOnSlope();
    }

    private void SpawnRocksAtRandomPointOnSlope()
    {
        for (int i = 0; i < StonesToSpawn; i++)
        {
            float xCordinate = UnityEngine.Random.Range(meshCollider.bounds.min.x, meshCollider.bounds.max.x);
            float yCordinate = (transform.position.y + meshCollider.bounds.extents.y);
            float zCordinate = UnityEngine.Random.Range(transform.position.z, (transform.position.z + meshCollider.bounds.extents.z * 2));
            Vector3 origin = new Vector3(xCordinate, yCordinate, zCordinate);
            rays.Add(new Ray(origin, new Vector3(0, -100, -20)));
        }

        foreach (Ray ray in rays)
        {
            RaycastHit rayInfo;
            if (Physics.Raycast(ray, out rayInfo, maxRayDistance, layerMask))
            {
                GameObject newRock =  Instantiate(rockPrefab, rayInfo.point, transform.rotation);
                newRock.transform.parent = transform;
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        foreach (Ray ray in rays)
        {
            Debug.DrawRay(ray.origin, ray.direction * 200, Color.red);
        }
        /*
        Debug.DrawRay(new Vector3(meshCollider.bounds.min.x, (transform.position.y + meshCollider.bounds.extents.y), transform.position.z), new Vector3(0, 100, 20), Color.red);
        Debug.DrawRay(new Vector3(meshCollider.bounds.max.x, (transform.position.y + meshCollider.bounds.extents.y), transform.position.z), new Vector3(0, 100, 20), Color.red);
        Debug.DrawRay(new Vector3(meshCollider.bounds.min.x, (transform.position.y - meshCollider.bounds.extents.y), (transform.position.z + meshCollider.bounds.extents.z * 2)), new Vector3(0, 100, 20), Color.red);
        Debug.DrawRay(new Vector3(meshCollider.bounds.max.x, (transform.position.y - meshCollider.bounds.extents.y), (transform.position.z + meshCollider.bounds.extents.z * 2)), new Vector3(0, 100, 20), Color.red);
        */
    }
}
