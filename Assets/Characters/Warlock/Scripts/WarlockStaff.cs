using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarlockStaff : ChargeWeaponScript {
    public GameObject SpellCircle;

    override
    protected void prepAttack() {
        damage *= (charge / 1.5f + 1);
        bulletSize += charge * 3f;
        recoil += charge * 300;
    }

    override
    protected void resetAttack() {
        bulletSize -= charge * 3f;
        damage /= (charge / 2 + 1);
        recoil -= charge * 300;
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
