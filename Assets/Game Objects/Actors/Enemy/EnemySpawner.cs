using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameObject enemyPrefab, enemyParent, enemy;
    float timer, currentTime;
    Vector3 randomPos;

    // Start is called before the first frame update
    void Start()
    {
        enemyParent = GameObject.FindGameObjectWithTag("Enemies");
        enemyPrefab = Resources.Load("Prefabs/BasicEnemy") as GameObject;
        timer = 5f;
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > currentTime)
        {
            currentTime = Time.time + timer;
            randomPos = new Vector3(Random.Range(-70f, 70f), 1.8f, Random.Range(-70f, 70f));
            enemy = Instantiate(enemyPrefab, randomPos, transform.rotation);
            enemy.transform.parent = enemyParent.transform;
        }
    }
}
