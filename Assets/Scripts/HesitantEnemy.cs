using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HesitantEnemy : Enemy
{
    [SerializeField]
    private float speedVariance;
    private float targetZ;

    // Start is called before the first frame update
    void Start()
    {
        targetZ = this.transform.position.z;
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
        if (Mathf.Abs(this.transform.position.z - targetZ) < .5) {
            targetZ = Random.Range(speed - speedVariance, speed + speedVariance) * Time.deltaTime + transform.position.z;
        }
        Vector3 target = new Vector3(transform.position.x, transform.position.y, targetZ);
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);


    }
}
