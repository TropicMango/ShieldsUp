using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingGloveScript : WeaponScript {
    override
    protected void Activate() {
        base.Activate();
        StartCoroutine(Activation());
    }

    IEnumerator Activation() {
        yield return new WaitForSeconds(0.8f);
        GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation);
        tempBullet.transform.localScale += new Vector3(0.3f, 0.3f, 0);
        BulletScrpit bulletScript = tempBullet.GetComponent<BulletScrpit>();
        bulletScript.setStats(damage * 3, 1, explosionSize, pierce, bonusBulletSize);
        Destroy(tempBullet, terminationTime);
        Vector3 tran = new Vector3(0, 600, 0);
        tran = transform.rotation * tran;
        player.GetComponent<Rigidbody2D>().AddForce(tran);
    }

    override
    protected void Attack() {
        //-----------------------------accounts for burst-----------------------------
        animations.Play("Reload"); //Play Animation
        StartCoroutine(Boxing());
    }

    IEnumerator Boxing() {
        StartCoroutine(AttackCommand());
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(AttackCommand());
    }
}
