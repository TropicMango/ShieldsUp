using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarPillScript : UpgradePickUpScript {

    private PlayerScript player;
    private float cooldown = 0;
    private float duration = 2;
    private bool active = false;
    private bool boosted = false;
    private float boost = 12f;

	// -------------------------- Description ---------------------------
    // boosts speed half the time
	void Start () {
		
	}

    void Update() {
        if (active) {
            if(Time.time > cooldown) {
                if (boosted) {
                    player.movementSpeed -= boost;
                    boosted = false;
                } else {
                    player.movementSpeed += boost;
                    boosted = true;
                }
                cooldown = Time.time + duration;
            }
        }
  
    }

    override
    public void upgrade(PlayerScript player) {
        this.player = player;
        active = true;
        cooldown = Time.time + duration;
    }
}
