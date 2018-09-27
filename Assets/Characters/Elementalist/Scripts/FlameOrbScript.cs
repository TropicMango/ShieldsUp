using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameOrbScript : BulletScrpit {
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
        return damage*1.5f;
    }
}
