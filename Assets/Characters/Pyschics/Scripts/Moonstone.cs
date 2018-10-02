using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonstone : pedestalScript {
    override
    public void enhance(PlayerScript player) {
        WeaponScript weap = player.GetWeaponScript();
        weap.damage += 5f;
        weap.bonusBulletSize += 0.1f;
    }
}
