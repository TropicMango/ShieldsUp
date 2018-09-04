﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScrpit : DamageScrpit {

    public float movementSpeed;
    public float offSetDist;
    public float explosionSize;
    public float damage;
    public float pierce;
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

    override
    public float Hit() {
        //-----------------------------pierce-----------------------------
        if (pierce == 0) {
            movementSpeed = 0; // pretend to be dead to keep the trail alive
            gameObject.SetActive(false);
            Destroy(GetComponent <Collider2D>());
            Destroy(gameObject,3);
        } else {
            pierce -= 1; //removes one off the pierce counter
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
