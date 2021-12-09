using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] enemies;

    public Transform xLeft;
    public Transform xRight;
    public Transform yUp;
    public Transform yDown;

    public float timeSpawnEnemies = 1;
    public float repeatSpawnRateEnemies = 3;

    public GameObject[] fruits;
    public float timeSpawnFruits = 0.5f;
    public float repeatSpawnRateFruits = 1.5f;


    void Start()
    {
        InvokeRepeating("SpawnEnemies", timeSpawnEnemies, repeatSpawnRateEnemies);
        InvokeRepeating("SpawnFruits", timeSpawnFruits, repeatSpawnRateFruits);
    }

    public void SpawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0);
        var xRandom = Random.Range(xLeft.position.x, xRight.position.x);
        var yRange = Random.Range(yDown.position.y, yUp.position.y);
        var xObject = Random.Range(0, enemies.Length);

        spawnPosition = new Vector3(xRandom, yRange, 0);

        GameObject enemy = Instantiate(enemies[xObject], spawnPosition, gameObject.transform.rotation);
    }  
    
    public void SpawnFruits()
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0);
        var xRandom = Random.Range(xLeft.position.x, xRight.position.x);
        var yRange = Random.Range(yDown.position.y, yUp.position.y);
        var xObject = Random.Range(0, fruits.Length);

        spawnPosition = new Vector3(xRandom, yRange, 0);

        GameObject fruit = Instantiate(fruits[xObject], spawnPosition, gameObject.transform.rotation);
    }


}
