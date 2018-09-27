using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBall : pedestalScript {
    override
    public void enhance(PlayerScript player) {
        player.hp += 50;
        player.movementSpeed += 5;
    }
}
