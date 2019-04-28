using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterAbstract {
    [SerializeField]
    protected float LineDuration;

    [SerializeField]
    protected int selfHarm;

    [SerializeField]
     AudioSource fireSound;


    // Start is called before the first frame update
    void Start () {
        NextFire = 0;
    }

    // Update is called once per frame
    void Update () {}


    public void Shoot (GameObject hand) {
        Debug.Log("Entering Shoot");
        Debug.Log("NextFire: " + NextFire);
        if (Time.time > NextFire) {
            NextFire = Time.time + TimeBetweenCast;
            Health -= selfHarm;
            fireSound.Play();

            RaycastHit enemyTarget;
            int enemyLayer = 1 << 9;
            //Raycast position, direction pointing, hitinfo???, length, Tree Layer, default
            bool enemyHit = Physics.Raycast(hand.transform.position,
                hand.transform.forward,
                out enemyTarget,
                Range,
                enemyLayer,
                QueryTriggerInteraction.UseGlobal);
            if (enemyHit) {
                Debug.Log("Enemy is Hit");
                GameObject target = enemyTarget.transform.gameObject;
                Enemy enemy = target.GetComponent<Enemy>();

                if (enemy != null) {
                    enemy.Hurt(Damage);
                    Debug.Log("Damage Calculated");
                }
            }
        }
    }
}