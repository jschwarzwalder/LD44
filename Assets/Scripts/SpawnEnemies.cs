using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
    private int enemyIndex;
    private float time = 0.0f;
    private Countdown gameTimer;
    
    [SerializeField] Enemy[] toSpawn;
    [SerializeField] float spawnDelay;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [SerializeField] float maxX;
    [SerializeField] float minX;



    // Use this for initialization
    void Start () {
        enemyIndex = 0;
        GameObject gameTimerObject = GameObject.FindWithTag("Timer");
        if (gameTimerObject != null){
            gameTimer = gameTimerObject.GetComponent<Countdown>();
        }
    }

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime;

        if (time >= spawnDelay) {
            time = 0.0f;
            if (gameTimer.getTime() <= 0) {
                Spawn();
            }
        }
    }

    private void Spawn () {
        Debug.Log("Spawn");
        Enemy enemy = getNextEnemy();
        Debug.Log("Enemy: " + enemy);
        if (enemy != null) {
            GameObject newSpawn = GameObject.Instantiate(enemy.gameObject);
            Vector3 enemyPosition = this.transform.position;
            enemyPosition.x += Random.Range(minX, maxX);
            enemyPosition.y += Random.Range(minY, maxY);
            newSpawn.transform.position = enemyPosition;
        }
    }

    protected Enemy getNextEnemy () {
        if (enemyIndex < toSpawn.Length) {
            Enemy currentEnemy = toSpawn[enemyIndex];
            enemyIndex += 1;
            return currentEnemy;
        }
        else {
            return null;
        }
    }
}