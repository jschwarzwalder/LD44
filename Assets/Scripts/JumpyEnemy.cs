using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpyEnemy : Enemy
{
    [SerializeField]
    private float maxHeight;
    [SerializeField]
    private float ground;

    private float jump;

    // Start is called before the first frame update
    void Start() {
        base.Start();
        jump = this.transform.position.y;
    }

    void OnTriggerEnter(Collider player)
    {

    }

    override protected void Walk()
    {
        if (Mathf.Abs(this.transform.position.y - jump) < .5) {
            jump = Random.Range(ground, maxHeight);
        }
        Vector3 target = new Vector3(transform.position.x, jump, transform.position.z - speed);
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);


    }
}
