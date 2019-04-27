using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    private int enemyIndex;
    private float time = 0.0f;


    [SerializeField] Enemy[] toSpawn;
    [SerializeField] float spawnDelay;
    [SerializeField] float groundLevel;
    [SerializeField] float max;
    [SerializeField] float min;



    // Use this for initialization
    void Start()
    {
        enemyIndex = 0;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnDelay)
        {
            time = 0.0f;

            Spawn();

        }

    }

    private void Spawn()
    {
        Debug.Log("Spawn");
        GameObject enemy = getNextEnemy();
        Debug.Log("Enemy: " + enemy);
        if (enemy != null)
        {
            enemy.transform.localScale = new Vector3(1, 1, 1);
            GameObject newSpawn = GameObject.Instantiate(enemy.gameObject);
            Vector3 enemyPosition = this.transform.position;
            enemyPosition.x += Random.Range(min, max);
            enemyPosition.y = groundLevel;
            newSpawn.transform.position = enemyPosition;

        }


    }

    protected GameObject getNextEnemy()
    {
        if (enemyIndex < toSpawn.Length)
        {
            GameObject currentEnemy = toSpawn[enemyIndex];
            enemyIndex += 1;
            return currentEnemy;
        }
        else
        {
            return null;
        }

    }


}




