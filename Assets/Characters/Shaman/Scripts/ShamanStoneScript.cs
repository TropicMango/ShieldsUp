using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanStoneScript : pedestalScript {


    override
    public void enhance(PlayerScript player) {
        player.movementSpeed += 2;
        player.GetWeaponScript().damage += 1;
    }
}
