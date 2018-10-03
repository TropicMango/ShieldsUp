using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour {
    private float movementSpeed;
    public float RotationSpeed;
    public float bulletSpray;
    public float recoil;
    public float bulletSize;
    public float damage;
    public float pierce;
    public float bulletSpeed;
    public float reload;
    public float abilityRecharge;
    public float activationTime;
    public float delay;
    public float terminationTime;
    public AddonEffectScript[] Effects;
    public AddonOnhitScript[] Onhits;

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
     float activationTime,
     float delay,
     float terminationTime,
     AddonEffectScript[] Effects,
     AddonOnhitScript[] Onhits) {
        this.movementSpeed = movementSpeed;
        this.RotationSpeed = RotationSpeed;
        this.bulletSpray = bulletSpray;
    }
}
