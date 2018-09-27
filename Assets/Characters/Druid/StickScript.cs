using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickScript : pedestalScript {
    override
    public void enhance(PlayerScript player) {
        WeaponScript weap = player.GetWeaponScript();
        weap.bulletSpray *= 1.2f;
        weap.damage *= 1.2f;
    }
}