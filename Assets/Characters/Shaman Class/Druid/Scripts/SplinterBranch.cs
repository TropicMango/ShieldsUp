using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplinterBranch : WeaponScript {
    public int numShots;
    public GameObject vine;

    override
    protected void Attack() {
        //-----------------------------accounts for burst-----------------------------
        if (!animations.GetCurrentAnimatorStateInfo(0).IsName("Activate")) {
            animations.Play("Reload"); //Play Animation
            StartCoroutine(OrbAttack());
        }
    }

    private IEnumerator OrbAttack() {
        for (int i = 0; i < numShots/2; i++) {
            StartCoroutine(AttackCommand(-bulletSpray + bulletSpray * 2 / (numShots/2 - 1) * i));
        }
        yield return new WaitForSeconds(reload/2);
        for (int i = 0; i < numShots/2; i++) {
            StartCoroutine(AttackCommand(-bulletSpray/2 + bulletSpray/2 * 2 / (numShots/2 - 1) * i));
        }
    }

    override
    protected void Activate() {
        base.Activate();
        StartCoroutine(StartAnimation());
    }

    private IEnumerator StartAnimation() {
        yield return new WaitForSeconds(0.5f);
        Instantiate(vine, transform.position, transform.rotation);
    }

    override
    public void activateStatsModifier() {
        reload *= 2;
        bulletSpray *= 2;
    }
}
