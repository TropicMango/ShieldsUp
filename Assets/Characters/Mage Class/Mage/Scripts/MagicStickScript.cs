using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStickScript : pedestalScript {


    override
    public void enhance(PlayerScript player) {
        player.GetWeaponScript().damage += 5;
    }
}
