using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStaffScript : WeaponScript {

	// Use this for initialization
	void Start () {}

    override
    public bool Activate(Rigidbody2D player) {
        if (base.Activate(player)) {
            StartCoroutine(Activation(2.5f, player));
        }
        return true;
    }

    IEnumerator Activation(float waitTime, Rigidbody2D player) {
        yield return new WaitForSeconds(waitTime);
        GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation);
        tempBullet.transform.localScale += new Vector3(0.3f, 0.3f, 0);
        tempBullet.GetComponent<BulletScrpit>().damage *= 5;
        Destroy(tempBullet, 5);

        Vector3 tran = new Vector3(0, -300, 0);
        tran = transform.rotation * tran;
        player.AddForce(tran);
    }
}
