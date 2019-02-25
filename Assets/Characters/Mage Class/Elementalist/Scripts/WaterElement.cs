using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterElement : pedestalScript {
    override
    public void enhance(PlayerScript player) {
        WeaponScript weap = player.GetWeaponScript();
        weap.bulletSize += 0.1f;
        weap.bulletSpeed -= 0.05f;
    }
}
