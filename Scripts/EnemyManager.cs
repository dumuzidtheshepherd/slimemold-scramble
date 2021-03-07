using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public List<GameObject> enemies;
    private float spawnRate;
    private float nextSpawn;
    private float startTime;
    private int spawnIndex, enemyIndex;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 1f;
        nextSpawn = startTime = Time.time;
        nextSpawn += 1f;
        Debug.Log("hi noweeee");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            spawnIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
            if (Time.time - startTime > 20f)
            {
                int giantChance = UnityEngine.Random.Range(0, 10);
                enemyIndex = spawnIndex > spawnPoints.Length - 5 && enemyIndex != 1 && GameObject.Find("giant cornmeal(Clone)") == null && giantChance >= 8 ? 1 : 0;
            } else
            {
                enemyIndex = 0;
            }
            Debug.Log(enemyIndex);
            Instantiate(enemies[enemyIndex], spawnPoints[spawnIndex].transform.position, Quaternion.identity);
            nextSpawn = Time.time + spawnRate;
            spawnRate -= 0.05f;
            spawnRate = Mathf.Clamp(spawnRate, .4f, 2f);
        }
    }
}
