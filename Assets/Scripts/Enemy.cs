using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterAbstract {
    [SerializeField]
    protected float speed;

    // Start is called before the first frame update
    void Start()
    {
        
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
        this.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);


        
    }
}
