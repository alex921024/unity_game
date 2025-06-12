using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    float moveSpeed;
    [SerializeField] GameObject[] floorPrefabs;
    //§PÂ_¶¡¹j
    private Vector3? lastFloorPosition = null;
    //¶¡¹j¶ZÂ÷
    public float minDistance = 2f;
    public float maxDistance = 4f;

    Vector3 newPos;
    public void SpawnFoolr()
    {
        int r = Random.Range(0, floorPrefabs.Length);
        GameObject floor = Instantiate(floorPrefabs[r], transform);
        int attempt = 0;
        do
        {
            float x = Random.Range(9.0f, 9.2f);
            float y = Random.Range(-4f, 4f);
            newPos = new Vector3(x, y, 0);
            
           
        }
        while (lastFloorPosition != null &&
               (Vector3.Distance(newPos, lastFloorPosition.Value) < minDistance ||
                Vector3.Distance(newPos, lastFloorPosition.Value) > maxDistance) &&
               attempt < 100);
        floor.transform.position = newPos;
        lastFloorPosition = newPos;
    }
}
