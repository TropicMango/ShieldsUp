using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerMapScript : pedestalScript {
    override
    public void pickUp(PlayerScript player) {
        if(player.characterClass == "Base") {
            Debug.Log(characterManager);
            Debug.Log(futureEvo);
            characterManager.evoPlayer(futureEvo);
        } else {
            player.movementSpeed += 5;
        }
    }
}
