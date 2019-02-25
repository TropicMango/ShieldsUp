using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindElement : pedestalScript {
    override
    public void enhance(PlayerScript player) {
        WeaponScript weap = player.GetWeaponScript();
        weap.bulletSpeed += 0.05f;
    }
}
