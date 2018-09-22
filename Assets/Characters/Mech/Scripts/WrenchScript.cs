using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchScript : WeaponScript {
    public GameObject wallObject;

    override
    protected void Activate() {
        base.Activate();
        StartCoroutine(Activation());
    }

    IEnumerator Activation() {
        yield return new WaitForSeconds(0.35f);
        GameObject wall = Instantiate(wallObject, transform.position, transform.rotation);
        wall.transform.Translate(new Vector2(0, 0.75f));
        Destroy(wall, 25);

        Vector3 tran = new Vector3(0, -100, 0);
        tran = transform.rotation * tran;
        player.GetComponent<Rigidbody2D>().AddForce(tran);
    }
}
