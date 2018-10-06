using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats {
    private float movementSpeed;
    private float RotationSpeed;
    private float bulletSpray;
    private float recoil;
    private float bulletSize;
    private float damage;
    private float pierce;
    private float bulletSpeed;
    private float reload;
    private float abilityRecharge;
    private AddonEffectScript[] Effects;
    private AddonOnhitScript[] Onhits;

    public void setStats(
     float movementSpeed,
     float RotationSpeed,
     float bulletSpray,
     float recoil,
     float bulletSize,
     float damage,
     float pierce,
     float bulletSpeed,
     float reload,
     float abilityRecharge,
     AddonEffectScript[] Effects,
     AddonOnhitScript[] Onhits) {
        this.movementSpeed = movementSpeed;
        this.RotationSpeed = RotationSpeed;
        this.bulletSpray = bulletSpray;
        this.recoil = recoil;
        this.bulletSize = bulletSize;
        this.damage = damage;
        this.pierce = pierce;
        this.bulletSpeed = bulletSpeed;
        this.reload = reload;
        this.abilityRecharge = abilityRecharge;
    }


    public void setStats(PlayerScript player) {
        player.movementSpeed = this.movementSpeed;
        WeaponScript WS = player.GetWeaponScript();
        Debug.Log(WS);
        WS.RotationSpeed = this.RotationSpeed;
        WS.bulletSpray = this.bulletSpray;
        WS.recoil = this.recoil;
        WS.bulletSize = this.bulletSize;
        WS.damage = this.damage;
        WS.pierce = this.pierce;
        WS.bulletSpeed = this.bulletSpeed;
        WS.reload = this.reload;
        WS.abilityRecharge = this.abilityRecharge;
    }

}
