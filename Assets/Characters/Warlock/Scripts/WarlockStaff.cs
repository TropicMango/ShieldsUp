using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarlockStaff : WeaponScript {
    private float charge;
    private float maxCharge = 1.5f; // 1.5
    public float chargeAmount = 0.005f;// 0.005
    public GameObject SpellCircle;

    public void storeEnergy() {
        if (Time.time > reloadCoolDown) {
            if (charge == 0) {
                animations.Play("storeEnergy");
            }
            if (charge < maxCharge) {
                charge += chargeAmount;
            }
        }
    }

    override
    public void checkAttack() {
        if (charge != 0 && Time.time > reloadCoolDown) {
            reloadCoolDown = Time.time + reload;
            damage *= (charge/1.5f+1);
            bonusBulletSize += charge/2f;
            recoil += charge * 300;
            this.Attack(); // tranform is passed for knock back
        }
    }

    override
    protected void followUp() {
        bonusBulletSize -= charge/2;
        damage /= (charge / 2 + 1);
        recoil -= charge * 300;
        charge = 0;
    }

    override
    protected void Activate() {
        StartCoroutine(destroyCircle(Instantiate(SpellCircle, player.transform.position + new Vector3 (0,0,65), Quaternion.Euler(0,0,0))));
    }

    private IEnumerator destroyCircle(GameObject circle) {
        Destroy(circle, 5.5f);
        yield return new WaitForSeconds(5.4f);
        circle.GetComponent<CircleCollider2D>().enabled = false;
    }
}
