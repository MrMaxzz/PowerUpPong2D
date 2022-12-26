using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] powerUps;
    public float firstSpawnDelay = 10f;
    public float spawnRate = 20f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerUp", firstSpawnDelay, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPowerUp()
    {
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        int randompowerUp = Random.Range(0, powerUps.Length);

        Instantiate(powerUps[randompowerUp], spawnPoints[randomSpawnPoint].position, spawnPoints[randomSpawnPoint].rotation);
    }
}
