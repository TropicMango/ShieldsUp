using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScrpit : DamageScrpit {

    private float damage;
    private float movementSpeed;
    public float offSetDist;
    private float explosionSize;
    private float pierce;
    public GameObject explosion;

    // Use this for initialization
    void Start () {
        //determin how long this will fly
        transform.Translate(new Vector2(0, offSetDist));
	}

	// Update is called once per frame
	void FixedUpdate () {
        //moving the bullet
        transform.Translate(new Vector2(0, movementSpeed));
	}

    public void setStats(float damage, float movementSpeed, float explosionSize, float pierce, float bonusBulletSize) {
        this.damage = damage;
        this.movementSpeed = movementSpeed;
        this.explosionSize = explosionSize;
        this.pierce = pierce;
        transform.localScale += new Vector3(bonusBulletSize, bonusBulletSize, 0);
    }

    override
    public float Hit() {
        //-----------------------------pierce-----------------------------
        if (pierce == 0) {
            Destroy(gameObject,0.05f);
        } else if(pierce > 0) {
            pierce -= 1; //removes one off the pierce counter
        } else {
            return 0;
        }
        if (explosionSize > 0) {
            //create an explosion that dies after ___ seconds
            GameObject explo = Instantiate(explosion, transform.position, transform.rotation);
            explo.GetComponent<ExplosionScript>().init(damage, explosionSize);
            Destroy(explo, 3f);
            return 0;
        } else {
            return damage;
        }
    }

    public void DamageInc(float inc, int mode) { //modes{ 1:multiply, 2:add }
        if (mode == 1) {
            damage *= inc;
        } else {
            damage += inc;
        }
    }

    public void ExplosionInc(float inc, int mode) { //modes{ 1:multiply, 2:add }
        if (mode == 1) {
            explosionSize *= inc;
        } else {
            explosionSize += inc;
        }
    }
}
