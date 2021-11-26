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

    public float timeSpawn = 1;
    public float repeatSpawnRate = 3;

    void Start()
    {
        InvokeRepeating("SpawnEnemies", timeSpawn, repeatSpawnRate);
    }

    public void SpawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0);
        var xRandom = Random.Range(xLeft.position.x, xRight.position.x);
        var yRange = Random.Range(yDown.position.y, yUp.position.y);
        var xObject = Random.Range(0, enemies.Length);

        spawnPosition = new Vector3(xRandom, yRange, 0);

        GameObject enemie = Instantiate(enemies[xObject], spawnPosition, gameObject.transform.rotation);
    }


}
