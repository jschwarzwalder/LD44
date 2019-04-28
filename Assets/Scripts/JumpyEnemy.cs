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
        jump = this.transform.position.y;
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
        if (Mathf.Abs(this.transform.position.y - jump) < .5) {
            jump = Random.Range(ground, maxHeight);
        }
        Vector3 target = new Vector3(transform.position.x, jump, speed * Time.deltaTime);
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed);


    }
}
