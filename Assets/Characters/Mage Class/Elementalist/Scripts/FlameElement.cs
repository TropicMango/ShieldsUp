using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameElement : pedestalScript {
    override
    public void enhance(PlayerScript player) {
        WeaponScript weap = player.GetWeaponScript();
        weap.damage *= 1.3f;
    }
}