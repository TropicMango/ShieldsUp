using System.Collections.Generic;
using UnityEngine;

public class EnchantedFlowerScript : pedestalScript {
    override
    public void enhance(PlayerScript player) {
        player.GetWeaponScript().bonusBulletSize += 0.5f;
        player.GetWeaponScript().damage += 2;
    }
}