using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseExplorerScript : PlayerScript {
    override
    public void ActivateAbility() {
        if (Time.time > abilityCoolDown) {
            StartCoroutine(speedBoost());
            abilityCoolDown = Time.time + abilityRecharge;
        }
    }

    IEnumerator speedBoost() {
        movementSpeed += 30;
        yield return new WaitForSeconds(0.5f);
        movementSpeed -= 30;
    }
}
