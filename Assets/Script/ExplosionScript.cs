using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : DamageScrpit {

    public float damage;

    public void init(float damage, float explosionSize) {
        Debug.Log(transform.localScale);
        this.damage = damage;
        transform.localScale = new Vector3(explosionSize, explosionSize, 0);
        Debug.Log(transform.localScale);
    }
    override
    public float Hit() {
        return damage;
    }
}
