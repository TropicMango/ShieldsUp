using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerMapScript : pedestalScript {
    override
    public void enhance(PlayerScript player) {
        player.movementSpeed += 5;
    }
}
