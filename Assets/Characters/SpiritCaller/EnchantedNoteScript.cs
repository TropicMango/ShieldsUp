using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantedNoteScript : pedestalScript {
    override
    public void enhance(PlayerScript player) {
        WeaponScript weap = player.GetWeaponScript();
        weap.setReload(weap.reload * 0.8f);
    }
}
