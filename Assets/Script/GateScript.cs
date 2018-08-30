using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour {

    public BoxCollider2D[] gates;

    // Use this for initialization
    void Start () {
		
	}
	
    public void updateLocks(bool[] list) { //order: up, down, left, right
        for(int i=0; i<list.Length; i++) {
            if (list[i]) {
                gates[i].enabled = true;
            } else {
                gates[i].enabled = false;
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
