﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScrpit :  DamageScrpit{

    protected float damage;
    protected float movementSpeed;
    public float offSetDist;
    protected float pierce;
    protected float knockBack;
    protected AddonOnhitScript[] Onhits;
    protected AddonEffectScript[] Effects;

    // Use this for initialization
    void Start () {
        //determin how long this will fly
        transform.Translate(new Vector2(0, offSetDist));
        selfInit();
	}

    protected virtual void selfInit() { }

	// Update is called once per frame
	void FixedUpdate () {
        //moving the bullet
        transform.Translate(new Vector2(0, movementSpeed));
        triggerEffect();
	}

    public void setStats(float damage, float movementSpeed, float pierce = 0, float bonusBulletSize = 0) {
        this.damage = damage;
        this.movementSpeed = movementSpeed;
        this.pierce = pierce;
        transform.localScale += new Vector3(bonusBulletSize, bonusBulletSize, 0);
    }


    override
    public float Hit(GameObject gm) {
        //-----------------------------pierce-----------------------------
        if (pierce == 0) {
            triggerOnhit(gm);
            Destroy(gameObject,0.05f);
        } else if(pierce > 0) {
            pierce -= 1; //removes one off the pierce counter
        } else {
            return 0;
        }
        return damage;
    }

    protected void triggerOnhit(GameObject gm) {
        foreach (AddonOnhitScript Onhit in Onhits) {
            // Onhit.triggerEffect(gm.GetComponent<CharacterScript>());
        }
    }

    protected void triggerEffect() {
        foreach (AddonEffectScript effect in Effects) {
            effect.triggerEffect(this);
        }
    }

}
