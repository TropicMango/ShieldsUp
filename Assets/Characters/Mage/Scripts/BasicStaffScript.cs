using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStaffScript : WeaponScript {

    override
    protected void Activate() {
        base.Activate();
        StartCoroutine(Activation());
    }

    IEnumerator Activation() {
        yield return new WaitForSeconds(2.5f);
        GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation);
        tempBullet.transform.localScale += new Vector3(0.3f, 0.3f, 0);
        tempBullet.GetComponent<BulletScrpit>().setStats(damage * 5, bulletSpeed/2, explosionSize, pierce, bonusBulletSize);
        Destroy(tempBullet, 5);

        Vector3 tran = new Vector3(0, -300, 0);
        tran = transform.rotation * tran;
        player.GetComponent<Rigidbody2D>().AddForce(tran);
    }
}
