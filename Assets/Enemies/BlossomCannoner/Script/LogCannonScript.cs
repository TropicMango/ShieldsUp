﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogCannonScript : WeaponScript {
    public float numShots;

    override
    protected void Attack() {
        //-----------------------------accounts for burst-----------------------------
        if (!animations.GetCurrentAnimatorStateInfo(0).IsName("Activate")) {
            animations.Play("Reload"); //Play Animation
            for (int i = 0; i < numShots; i++) {
                StartCoroutine(AttackCommand(-bulletSpray + bulletSpray * 2 / (numShots - 1) * i));
            }
        }
    }
}
