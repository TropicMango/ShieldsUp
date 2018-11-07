using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerScript : WeaponScript {

    public GameObject throwingDagger;

    override
    protected void Activate() {
        GameObject tempBullet = Instantiate(throwingDagger, transform.position, transform.rotation);
        tempBullet.GetComponent<BulletScrpit>().setStats(damage, bulletSpeed*5, pierce, bulletSize);
        Destroy(tempBullet, 2);
    }
}
