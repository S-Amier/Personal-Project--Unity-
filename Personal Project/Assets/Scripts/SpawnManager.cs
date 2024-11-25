using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRangeX = 21.5f;
    private float spawnPosY = 0.8f;
    private float spawnPosZ = 18.0f;
    public GameObject [] shipPrefabs;

    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnRandomShip", 2, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnRandomShip()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

        int shipIndex = Random.Range(0, shipPrefabs.Length);
        Instantiate (shipPrefabs[shipIndex], spawnPos, shipPrefabs[shipIndex].transform.rotation);
    }
}
