using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HesitantEnemy : Enemy
{
    [SerializeField]
    private float backtrack;
    private float zMovement;

    // Start is called before the first frame update
    void Start()
    {
        zMovement = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    void OnTriggerEnter(Collider player)
    {

    }

    protected void Walk()
    {
        if (Mathf.Abs(this.transform.position.z - zMovement) < .5) {
            float velocity = speed * Time.deltaTime;
            zMovement = Random.Range(velocity - backtrack , this.transform.position.z + backtrack);
        }
        Vector3 target = new Vector3(0, 0, zMovement);
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed);


    }
}
