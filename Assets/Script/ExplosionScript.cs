using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : DamageScrpit {

    public float damage;

    public void init(float damage, float explosionSize) {
        this.damage = damage;
        transform.localScale = new Vector3(explosionSize, explosionSize, 0);
    }
    override
    public float Hit() {
        return damage;
    }
}
