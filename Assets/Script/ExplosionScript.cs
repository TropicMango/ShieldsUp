using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : DamageScrpit {

    public float damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    override
    public float Hit() {
        return damage;
    }
}
