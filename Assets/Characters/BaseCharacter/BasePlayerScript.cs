using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerScript : PlayerScript {


    // Use this for initialization
    void Start() {
        Rb = GetComponent<Rigidbody2D>();
        currentItems = new List<string>();
        //Instantiate(camera, transform);
    }

    override
    protected  void updateWeapon() {
        if (Rb.velocity.x > 0) {
            updatePlayerSprite(true);
        } else {
            updatePlayerSprite(false);
        }
    }

    private void Update() {

    }

    override
    public PlayerStats getStats() {
        if (!weapon) {
            return null;
        }
        return weaponScript.GetWeapStats(movementSpeed);
    }

}
