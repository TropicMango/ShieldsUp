using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeWeaponScript : WeaponScript {
    protected float charge;
    public float maxCharge = 1.5f;
    public float chargeAmount = 0.005f;

    override
    public void checkAttack() {
        if (Input.GetKey(KeyCode.Space)) {
            storeEnergy();
        } else {
            releaseEnergy();
        }
    }

    protected virtual void releaseEnergy() {
        //-----------Check for charge & cd-----------------
        if (charge != 0 && Time.time > reloadCoolDown) {
            reloadCoolDown = Time.time + reload;
            prepAttack();
            this.Attack();
        }
    }

    protected void storeEnergy() {
        //-----------Store Energy-----------------
        if (Time.time > reloadCoolDown) {
            if (charge == 0) {
                animations.Play("storeEnergy");
            }
            if (charge < maxCharge) {
                charge += chargeAmount;
            }
        }
    }

    protected virtual void prepAttack() {
    }

    protected virtual void resetAttack() { 
    }

    override
    protected void followUp() {
        //-----------reset bullet status-----------------
        resetAttack();
        charge = 0;
    }
}
