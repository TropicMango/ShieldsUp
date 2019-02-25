using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearScript : pedestalScript {

    override
    public void enhance(PlayerScript player) {
        player.GetWeaponScript().damage += 2;
        player.movementSpeed += 1;
    }
}
