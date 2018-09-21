using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarlockStaff : WeaponScript {
    private float charge;
    private float maxCharge = 1.5f;
    
    public void storeEnergy() {
        if (charge < maxCharge) {
            Debug.Log(charge);
            charge += 0.005f;
        }
    }

    override
    public void checkAttack(Rigidbody2D Rb) {
        if (charge != 0 && Time.time > coolDown) {
            coolDown = Time.time + reload;
            damage *= (charge/2+1);
            bonusBulletSize += charge;
            this.Attack(Rb); // tranform is passed for knock back
        }
    }

    override
    protected void followUp() {
        bonusBulletSize -= charge;
        damage /= (charge / 2 + 1);
        charge = 0;
    }
}
