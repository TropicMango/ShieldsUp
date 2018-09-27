using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarlockScript : PlayerScript {
    private float castBuff = 4;

    override
    public void Attack() {
        if (Input.GetKey(KeyCode.Space)) {
            ((WarlockStaff)weaponScript).storeEnergy();
        } else { 
            weaponScript.checkAttack();
        }
        // tranform is passed for knock back
    }

    override
    protected void extraTriggernEnter(GameObject colli) {
        // override me
        if(colli.tag == "playerSpecial") {
            ((WarlockStaff)weaponScript).chargeAmount *= castBuff;
            ((WarlockStaff)weaponScript).animations.speed *= castBuff;
        }
    }

    protected void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "playerSpecial") {
            ((WarlockStaff)weaponScript).chargeAmount /= castBuff;
            ((WarlockStaff)weaponScript).animations.speed /= castBuff;
        }
    }
}
