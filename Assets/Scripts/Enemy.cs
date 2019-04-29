using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterAbstract {
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int EndDamage;
    private float edge = Mathf.NegativeInfinity;
    private Player player;
    [SerializeField]
    private GameObject explosionPrefab;

    private SpawnEnemies spawner;

    public static int EnemyCount { get; private set; }

    // Start is called before the first frame update
    protected void Start() {
        ++EnemyCount;
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnEnemies>();
    }

    // Update is called once per frame
    protected void Update()
    {
        Walk();
        DetectEdge();
    }

    void OnTriggerEnter(Collider player)
    {
        
    }

    private void OnDestroy () {
        --EnemyCount;
        if (EnemyCount == 0 && !spawner.HasNext()) {
            GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
            Countdown timer = timerObject.GetComponent<Countdown>();
            timer.endGame();
        }
    }

    protected void DetectEdge () {
        if (edge == Mathf.NegativeInfinity) {
            GameObject aPlayer = GameObject.FindWithTag("Player");
           if (aPlayer != null) {
                edge = aPlayer.transform.position.z - 5;
                player = aPlayer.GetComponent<Player>();
            }

        }
        if (this.transform.position.z < edge) {
            Debug.Log("Object past player has been destroyed.");
            Destroy(gameObject);
            player.Hurt(EndDamage);
        }
    }

    protected virtual void Walk()
    {
        this.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
    }

    

    override public void Hurt(int damage)
    {
        Health -= damage;
        if (Health < 0) {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
