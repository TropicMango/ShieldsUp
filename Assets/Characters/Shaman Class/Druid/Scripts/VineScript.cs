using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineScript : BulletScrpit {
    private void Start() {
        setStats(10, 0.1f, 100, 0);
    }

    override
    public float Hit(GameObject gm) {
        StartCoroutine(gm.GetComponent<CharacterScript>().stun(3));
        return 0;
    }

}