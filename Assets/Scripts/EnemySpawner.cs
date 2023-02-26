using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] private GameObject[] enemyPrefabs; 
    public float time = 2.0f;
    
    
   
    // Start is called before the first frame update
    private void Start()
    {
        float time = PlayerPrefs.GetFloat("TimeSpawn");
        InvokeRepeating("SpawnEnemies", 2.0f, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
    
        int index = UnityEngine.Random.Range(0, spawnPoints.Length);
        int rand = UnityEngine.Random.Range(0, enemyPrefabs.Length);

        if(rand < enemyPrefabs.Length) {
            GameObject enemyToSpawn = enemyPrefabs[rand];
            Instantiate(enemyToSpawn, spawnPoints[index].position, UnityEngine.Quaternion.identity);
        }
    }

    
}
