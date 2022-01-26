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

    public GameObject[] fruits;

    public float timeSpawnFruits = 0.5f;
    public float repeatSpawnRateFruits = 1.5f;
    public float timeSpawnEnemies = 1;
    public float repeatSpawnRateEnemies = 3;

    public float difficultyTime;


    void Start()
    {
        StartCoroutine("EnemyDifficulty");
        StartCoroutine("FruitsDifficulty");
    }

    private void Update()
    {
        difficultyTime += Time.deltaTime;

        if (difficultyTime > 10 && difficultyTime < 20)
        {
            repeatSpawnRateEnemies = 2;
            repeatSpawnRateFruits = 3;
        }
        if (difficultyTime > 20 && difficultyTime < 30)
        {
            repeatSpawnRateEnemies = 1;
            repeatSpawnRateFruits = 4;
        }
        if (difficultyTime > 30 && difficultyTime < 50)
            repeatSpawnRateEnemies = 0.75f;
        if (difficultyTime > 50)
            repeatSpawnRateEnemies = 0.5f;
    }

    IEnumerator EnemyDifficulty()
    {
        yield return new WaitForSeconds(repeatSpawnRateEnemies);
        SpawnEnemies();
        StartCoroutine("EnemyDifficulty");
    }  
    
    IEnumerator FruitsDifficulty()
    {
        yield return new WaitForSeconds(repeatSpawnRateFruits);
        SpawnFruits();
        StartCoroutine("FruitsDifficulty");
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
