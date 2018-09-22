using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterBeltScript : pedestalScript {
    override
    public void pickUp(PlayerScript player) {
        if (player.characterClass == "Base") {
            characterManager.evoPlayer(futureEvo);
        } else {
            player.hp += 50;
        }
        base.pickUp(player);
    }
}
