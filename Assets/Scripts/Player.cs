using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterAbstract 

{

    private LineRenderer laserLine;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
