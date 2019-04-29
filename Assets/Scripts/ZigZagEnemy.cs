using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagEnemy : Enemy { 
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;

    private float lean;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        lean = this.transform.position.x;
    }

    void OnTriggerEnter(Collider player)
    {

    }

    override protected void Walk()
    {
        if (Mathf.Abs(this.transform.position.x - lean) < .5)
        {
            lean = Random.Range(minX, maxX);
        }
        Vector3 target = new Vector3(lean, transform.position.y, transform.position.z - speed);
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);


    }
}

