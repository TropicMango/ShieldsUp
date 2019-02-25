using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherScript : PlayerScript {
    override
    public void Attack() {
        if (Input.GetKey(KeyCode.Space)) {
            //((archerBowScript)weaponScript).storeEnergy();
        } else {
            weaponScript.checkAttack();
        }
        // tranform is passed for knock back
    }

}
