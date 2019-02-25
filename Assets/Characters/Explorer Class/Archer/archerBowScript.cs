using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archerBowScript : ChargeWeaponScript {
    override
    protected void prepAttack() {
        damage *= (charge / 1.5f + 1);
        bulletSize += charge * 3f;
        recoil += charge * 300;
    }

    override
    protected void resetAttack() {
        bulletSize -= charge * 3f;
        damage /= (charge / 2 + 1);
        recoil -= charge * 300;
    }

}
