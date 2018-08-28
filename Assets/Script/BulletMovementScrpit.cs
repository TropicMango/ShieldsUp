﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementScrpit : MonoBehaviour {

    public float terminationTime;
    public float movementSpeed;
    public float bulletSpray;
    public float offSetDist;

    // Use this for initialization
    void Start () {
        transform.Rotate(new Vector3(0, 0, Random.Range(-bulletSpray, bulletSpray)));
        Destroy(gameObject, terminationTime);
        transform.Translate(new Vector2(0, offSetDist));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(new Vector2(0, movementSpeed));
	}
}
