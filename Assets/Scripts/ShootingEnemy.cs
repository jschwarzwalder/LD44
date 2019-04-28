using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy {

    [SerializeField]
    private AudioSource fireSound;

    // Start is called before the first frame update
    void Start () {}

    // Update is called once per frame
    void Update () {
        Walk();
        Shoot();
    }

    void OnTriggerEnter (Collider player) {}

    public void Shoot () {
        Debug.Log("Entering Shoot");
        Debug.Log("NextFire: " + NextFire);
        if (Time.time > NextFire) {
            NextFire = Time.time + TimeBetweenCast;
            fireSound.Play();
            RaycastHit playertarget;
            int playerLayer = 1 << 8;
            //Raycast position, direction pointing, hitinfo???, length, Tree Layer, default
            bool playerIsHit = Physics.Raycast(transform.position,
                transform.forward,
                out playertarget,
                Range,
                playerLayer,
                QueryTriggerInteraction.UseGlobal);
            if (playerIsHit) {
                Debug.Log("Player is Hit");
                GameObject target = playertarget.transform.gameObject;
                Player player = target.GetComponent<Player>();
                if (player != null) {
                    player.Hurt(Damage);
                    Debug.Log("Damage Calculated");
                }
            }
        }
    }
}