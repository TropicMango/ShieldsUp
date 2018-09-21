using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingGloveScript : WeaponScript {
    override
    protected void Activate(Rigidbody2D player) {
        base.Activate(player);
        StartCoroutine(Activation(player));
    }

    IEnumerator Activation(Rigidbody2D player) {
        yield return new WaitForSeconds(0.8f);
        GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation);
        tempBullet.transform.localScale += new Vector3(0.3f, 0.3f, 0);
        BulletScrpit bulletScript = tempBullet.GetComponent<BulletScrpit>();
        bulletScript.setStats(damage * 3, 1, explosionSize, pierce, bonusBulletSize);
        Destroy(tempBullet, terminationTime);
        Vector3 tran = new Vector3(0, 600, 0);
        tran = transform.rotation * tran;
        player.AddForce(tran);
    }

    override
    protected void Attack(Rigidbody2D player) {
        //-----------------------------accounts for burst-----------------------------
        animations.Play("Reload"); //Play Animation
        StartCoroutine(Boxing(player));
    }

    IEnumerator Boxing(Rigidbody2D player) {
        StartCoroutine(AttackCommand(player));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(AttackCommand(player));
    }
}
