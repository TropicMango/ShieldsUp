using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanScript : PlayerScript {
    public GameObject totem;

    override
    public void ActivateAbility() {
        if (Time.time > abilityCoolDown) {
            dropTotem();
            abilityCoolDown = Time.time + abilityRecharge;
        }
    }

    void dropTotem() {
        Destroy(Instantiate(totem,transform.position, new Quaternion(0,0,0,0)),10);
    }
}
