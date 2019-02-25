using System.Collections.Generic;
using UnityEngine;

public class EnchantedFlowerScript : pedestalScript {
    override
    public void enhance(PlayerScript player) {
        player.GetWeaponScript().bulletSize += 0.2f;
        player.GetWeaponScript().damage += 2;
    }
}