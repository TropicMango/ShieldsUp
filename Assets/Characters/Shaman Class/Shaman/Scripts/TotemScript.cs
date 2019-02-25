using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemScript : EffectCircle {

    override
    public void triggerEffect(GameObject obj) {
        if (obj.tag == "Enemy") {
            obj.GetComponent<EnemyScript>().movementSpeed *= 0.5f;
        }
    }

    override
    public void exitEffect(GameObject obj) {
        if (obj.tag == "Enemy") {
            obj.GetComponent<EnemyScript>().movementSpeed /= 0.5f;
        }
    }

}
