using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterBeltScript : pedestalScript {

    override
    public void enhance(PlayerScript player) {
        player.hp += 50;
    }
}
