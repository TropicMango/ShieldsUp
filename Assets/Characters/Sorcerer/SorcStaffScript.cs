using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcStaffScript : WeaponScript {
    private int numActiveBolts = 55;

    override
    protected void Activate() {
        base.Activate();
        StartCoroutine(Activation());
    }

    IEnumerator Activation() {
        player.GetComponent<CharacterScript>().movementSpeed *= 0.05f;
        rotationLock = Time.time + 3.7f;
        yield return new WaitForSeconds(0.4f);
        float tempD = delay;
        delay = 0;
        for (int i = 0; i < numActiveBolts; i++) {
            yield return new WaitForSeconds(0.04f);
            StartCoroutine(AttackCommand(720 / numActiveBolts * i));
        }
        delay = tempD;
        player.GetComponent<CharacterScript>().movementSpeed /= 0.05f;
    }
}
