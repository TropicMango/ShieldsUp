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
        // -------------------- change me! --------------------------
        GameObject testR = Instantiate(Room[0], new Vector3(0, 0, 100), Quaternion.Euler(0,0,0));
        bool[] tempList = { false, false, true, false };
        testR.GetComponent<GateScript>().updateLocks(tempList);
        Instantiate(Room[0], new Vector3(0, 25, 100), Quaternion.Euler(0, 0, 0));
        Instantiate(Room[0], new Vector3(25, 0, 100), Quaternion.Euler(0, 0, 0));
        Instantiate(Room[0], new Vector3(0, -25, 100), Quaternion.Euler(0, 0, 0));

        Instantiate(Hall[0], new Vector3(0, 12.5f, 120), Quaternion.Euler(0, 0, 90));
        Instantiate(Hall[0], new Vector3(0, -12.5f, 120), Quaternion.Euler(0, 0, 90));
        Instantiate(Hall[0], new Vector3(12.5f, 0, 120), Quaternion.Euler(0, 0, 0));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
