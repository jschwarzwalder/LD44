using System.Collections;
using System.Collections.Generic;
using NewtonVR;
using UnityEngine;

public class Player : CharacterAbstract {
    [SerializeField]
    protected float LineDuration;
    [SerializeField]
    protected NVRHand LeftHand;
    [SerializeField]
    protected NVRHand RightHand;
    private LineRenderer laserLine;
    private bool rightController;
    private bool leftController;


    // Start is called before the first frame update
    void Start () {
        laserLine = GetComponent<LineRenderer>();
        NextFire = 0;
    }

    // Update is called once per frame
    void Update () {
        Shoot();
    }


    public void Shoot () {
        Debug.Log("Entering Shoot");
        Debug.Log("NextFire: " + NextFire);
        bool ButtonPressed = (LeftHand.IsCurrentlyTracked && (LeftHand.HoldButtonDown || LeftHand.UseButtonDown))
                || (RightHand.IsCurrentlyTracked && (RightHand.HoldButtonDown || RightHand.UseButtonDown));
        Debug.Log("VRInput: " + ButtonPressed);
        if (ButtonPressed && Time.time > NextFire) {
            NextFire = Time.time + TimeBetweenCast;
            laserLine.enabled = true;
            Debug.Log("Laser Visible");
            new WaitForSeconds(LineDuration);

            laserLine.enabled = false;
            Debug.Log("Laser Turned Off");
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