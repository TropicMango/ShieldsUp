using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalStaffScript : WeaponScript {
    public GameObject[] ElementalBolts;
    private int numBolts = 30;

    override
    protected void Activate() {
        base.Activate();
        StartCoroutine(Activation());
    }

    IEnumerator Activation() {
        yield return new WaitForSeconds(1.5f);
        for(int i=0; i<=numBolts; i++) {
            bullet = ElementalBolts[Random.Range(0, ElementalBolts.Length)];
            fireBullet(360 / numBolts * i);
        }
    }

    override
    protected void Attack() {
        //-----------------------------accounts for burst-----------------------------
        animations.Play("Reload"); //Play Animation
        bullet = ElementalBolts[Random.Range(0, ElementalBolts.Length)];//Random.Range(0, ElementalBolts.Length)
        StartCoroutine(AttackCommand());
    }
}
