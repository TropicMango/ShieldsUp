using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearScript : pedestalScript {

    override
    public void pickUp(PlayerScript player) {
        if (player.characterClass == "Base") {
            characterManager.evoPlayer(futureEvo);
        } else {
            player.GetWeaponScript().damage += 2;
            player.movementSpeed += 1;
        }
        base.pickUp(player);
    }
}
