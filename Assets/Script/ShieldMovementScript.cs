using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMovementScript : MonoBehaviour {

    public float RotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(new Vector3(0, 0, RotationSpeed));
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(new Vector3(0, 0, -RotationSpeed));
            
        }
    }
}
