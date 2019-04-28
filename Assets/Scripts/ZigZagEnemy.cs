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
        lean = this.transform.position.x;
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
        if (Mathf.Abs(this.transform.position.x - lean) < .5)
        {
            lean = Random.Range(minX, maxX);
        }
        Vector3 target = new Vector3(lean, transform.position.y, speed * Time.deltaTime);
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);


    }
}

