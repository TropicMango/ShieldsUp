using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchScript : WeaponScript {
    public GameObject wallObject;

    override
    public void Activate(Rigidbody2D player) {
        base.Activate(player);
        StartCoroutine(Activation(player));
    }

    IEnumerator Activation(Rigidbody2D player) {
        yield return new WaitForSeconds(0.25f);
        GameObject wall = Instantiate(wallObject, transform.position, transform.rotation);
        wall.transform.Translate(new Vector2(0, 0.75f));
        Destroy(wall, 25);

        Vector3 tran = new Vector3(0, -100, 0);
        tran = transform.rotation * tran;
        player.AddForce(tran);
    }
}
