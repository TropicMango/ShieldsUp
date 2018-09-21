using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychicScript : PlayerScript {


    override
    protected void updateWeapon() {
        if (Rb.velocity.x > 0) {
            updatePlayerSprite(true);
        } else {
            updatePlayerSprite(false);
        }
    }
}