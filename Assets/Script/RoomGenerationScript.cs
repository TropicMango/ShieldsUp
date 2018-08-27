using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerationScript : MonoBehaviour {

    // all of thse stand for the side you can exit
    public GameObject[] Room; 
    public GameObject[] Door; // Order: up, down, left, right
    public GameObject[] Hall; // Order: Horizontal, Vertical
    

    // Use this for initialization
    void Start () {
        // Instantiate(Room[0], new Vector3(0, 0, 0), Quaternion.Euler(0,0,0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
