using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindOrbScript : BulletScrpit {
    override
    public float Hit(GameObject gm) {
        //-----------------------------pierce-----------------------------
        if (pierce == 0) {
            Destroy(gameObject, 0.05f);
        } else if (pierce > 0) {
            pierce -= 1; //removes one off the pierce counter
        } else {
            return 0;
        }
        gm.GetComponent<Rigidbody2D>().AddForce(transform.rotation * new Vector2(0, 200));
        gm.GetComponent<CharacterScript>().slow(1, 0.5f);
        return damage;
    }
}
