using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanScript : PlayerScript {
    public GameObject totem;

    override
    public void ActivateAbility() {
        if (weaponScript.activatable()) {
            dropTotem();
        }
    }

    void dropTotem() {
        StartCoroutine(removeTotem(Instantiate(totem, transform.position, new Quaternion(0, 0, 0, 0))));
    }

    private IEnumerator removeTotem(GameObject totem) {
        yield return new WaitForSeconds(10);
        totem.GetComponent<CircleCollider2D>().enabled = false;
        Destroy(totem, 0.1f);
    }
}
