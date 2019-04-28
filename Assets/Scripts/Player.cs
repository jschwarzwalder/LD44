using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterAbstract {
    [SerializeField]
    protected float LineDuration;

    private LineRenderer laserLine;
    private bool rightController;
    private bool leftController;


    // Start is called before the first frame update
    void Start () {
        laserLine = GetComponent<LineRenderer>();
        rightController = OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote);
        leftController = OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote);
        NextFire = 0;
    }

    // Update is called once per frame
    void Update () {
        Shoot();
    }


    public void Shoot () {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && Time.time > NextFire) {
            NextFire = Time.time + TimeBetweenCast;
            laserLine.enabled = true;

            new WaitForSeconds(LineDuration);

            laserLine.enabled = false;
            RaycastHit enemyTarget;
            int enemyLayer = 1 << 9;
            //Raycast position, direction pointing, hitinfo???, length, Tree Layer, default
            bool enemyHit = Physics.Raycast(transform.position,
                transform.forward,
                out enemyTarget,
                Range,
                enemyLayer,
                QueryTriggerInteraction.UseGlobal);
            if (enemyHit) {
                GameObject target = enemyTarget.transform.gameObject;
                Enemy enemy = target.GetComponent<Enemy>();
                if (enemy != null) {
                    enemy.Hurt(Damage);
                }
            }
        }
    }
}