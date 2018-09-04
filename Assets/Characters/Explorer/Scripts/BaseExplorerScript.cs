using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseExplorerScript : PlayerScript {
    override
    public void ActivateAbility() {
        StartCoroutine(speedBoost());
    }

    IEnumerator speedBoost() {
        movementSpeed += 10;
        yield return new WaitForSeconds(0.2f);
        movementSpeed -= 10;
    }
}
