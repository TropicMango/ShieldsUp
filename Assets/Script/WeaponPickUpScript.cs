using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUpScript : MonoBehaviour {

    public GameObject weapItem;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        transform.Rotate(new Vector3(0, 0, 1));
    }

    public GameObject getItem() {
        return weapItem;
    }

}
