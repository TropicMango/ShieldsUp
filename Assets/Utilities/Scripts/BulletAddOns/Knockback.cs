using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : AddonOnhitScript {
    override
    public void triggerEffect(CharacterScript character, WeaponScript WS) {
        character.GetComponent<Rigidbody2D>().AddForce(WS.transform.rotation * new Vector2(0, 200));
    }
}
