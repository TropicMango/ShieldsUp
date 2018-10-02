﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCardScript : pedestalScript {
    override
    public void enhance(PlayerScript player) {
        WeaponScript weap = player.GetWeaponScript();
        weap.damage *= 1.5f;
        weap.bonusBulletSize -= 0.8f;
    }
}
