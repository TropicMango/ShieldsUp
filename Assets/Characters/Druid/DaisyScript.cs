using System.Collections.Generic;
using UnityEngine;

public class DaisyScript : pedestalScript {
    override
    public void enhance(PlayerScript player) {
        player.hp += 20;
        player.movementSpeed += 5;
    }
}