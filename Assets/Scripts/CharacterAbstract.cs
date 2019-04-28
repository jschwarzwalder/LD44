using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbstract : MonoBehaviour
{
    [SerializeField] protected float Health;
    [SerializeField] protected int Damage;
    [SerializeField] protected float TimeBetweenCast;
    [SerializeField] protected float Range;
    protected float NextFire;


    public void Shoot()
    {



    }

    public void Hurt (int damage) {
        Health -= damage;
    }
}
