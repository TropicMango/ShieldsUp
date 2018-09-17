using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanStoneScript : pedestalScript {

    override
    public void pickUp(PlayerScript player) {
        if (player.characterClass == "Base") {
            characterManager.evoPlayer(futureEvo);
        } else {
            player.GetWeaponScript().damage += 1;
            player.movementSpeed += 2;
        }
    }
}
