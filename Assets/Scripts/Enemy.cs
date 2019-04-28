using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterAbstract {
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int EndDamage;
    private float edge;
    private Player player;

    // Start is called before the first frame update
    void Start() {

        edge = -555;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    void OnTriggerEnter(Collider player)
    {
        
    }

    protected void DetectEdge () {
        int playerLayer = 1 << 8;
        if (edge <= -555) {
            GameObject aPlayer = GameObject.FindWithTag("Player");
           if (aPlayer != null && aPlayer.layer == playerLayer) {
                edge = aPlayer.transform.position.z;
                player = aPlayer.GetComponent<Player>();
            }

        }
        if (this.transform.position.z > edge) {
            Debug.Log("Object past player has been destroyed.");
            Destroy(this);
            player.Hurt(EndDamage);
            
        }
    }

    protected void Walk()
    {
        this.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
    }

    

    public void Hurt(int damage)
    {
        Health -= damage;
        if (Health < 0) {
            Destroy(this);
        }
    }
}
