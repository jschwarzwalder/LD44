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
        Debug.Log("Entering Shoot");
        Debug.Log("NextFire: " + NextFire);
       if (Time.time > NextFire)
        {
            NextFire = Time.time + TimeBetweenCast;
            RaycastHit playertarget;
            int playerLayer = 1 << 8;
            //Raycast position, direction pointing, hitinfo???, length, Tree Layer, default
            bool playerIsHit = Physics.Raycast(transform.position,
                transform.forward,
                out playertarget,
                Range,
                playerLayer,
                QueryTriggerInteraction.UseGlobal);
            if (playerIsHit)
            {
                Debug.Log("Player is Hit");
                GameObject target = playertarget.transform.gameObject;
                Player player = target.GetComponent<Player>();
                if (player != null)
                {
                    player.Hurt(Damage);
                    Debug.Log("Damage Calculated");
                }
            }
        }


    }

    public void Hurt (int damage) {
        Health -= damage;
    }
}
