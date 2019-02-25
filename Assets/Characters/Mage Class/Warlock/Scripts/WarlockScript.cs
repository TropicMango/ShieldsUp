using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarlockScript : PlayerScript {
    private float castBuff = 4;

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
