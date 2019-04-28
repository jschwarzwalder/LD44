using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        int enemyLayer = 1 << 9;
        int uiLayer = 1 << 5;


        RaycastHit targetHit;
        //Raycast position, direction pointing, hitinfo???, length, Tree Layer, default
        bool hit = Physics.Raycast(hand.transform.position,
            hand.transform.forward,
            out targetHit,
            Range,
            enemyLayer | uiLayer,
            QueryTriggerInteraction.UseGlobal);
        if (hit)
        {


            Debug.Log("Enemy is Hit");
            GameObject target = targetHit.transform.gameObject;
            Button button = target.GetComponent<Button>();
            if (button != null) {
                button.onClick.Invoke();
            }

            Enemy enemy = target.GetComponent<Enemy>();

            if (enemy != null)
            {
                if (Time.time > NextFire)
                {
                    NextFire = Time.time + TimeBetweenCast;
                    Health -= selfHarm;
                    fireSound.Play();
                    enemy.Hurt(Damage);
                    Debug.Log("Damage Calculated");

                }
            }
        }


    }
}