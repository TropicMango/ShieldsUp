using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarlockScript : PlayerScript {

    override
    public void Attack() {
        if (Input.GetKey(KeyCode.Space)) {
            ((WarlockStaff)weaponScript).storeEnergy();
        } else { 
            weaponScript.checkAttack(Rb);
        }
        // tranform is passed for knock back
    }
}
