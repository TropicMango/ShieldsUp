using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerationScript : MonoBehaviour {

    // all of thse stand for the side you can exit
    public GameObject[] Room; 
    public GameObject[] Door; // Order: up, down, left, right
    public GameObject[] Hall; // Order: Horizontal, Vertical
    public int numRooms = 10;
    private GameObject[,] Grid;

    private void Start() {
        GenrateRoom();
    }

    // Use this for initialization
    void GenrateRoom () {
        Grid = new GameObject[50,50];
        int x = 25;
        int y = 25;
        GameObject lastRoom;
        //----------------------------- First Room -----------------------------
        lastRoom = Instantiate(Room[0], new Vector3((x - 25) * 25, (y - 25) * 25, 100), Quaternion.Euler(0, 0, 0)); ;
        Grid[x, y] = lastRoom;

        for (int i=0; i<numRooms; i++) { 
            switch (Random.Range(0, 4)) { // Random Number for a direction
                case 0:
                    y += 1;
                    break;
                case 1:
                    y -= 1;
                    break;
                case 2:
                    x += 1;
                    break;
                case 3:
                    x -= 1;
                    break;
            }
            
            Debug.Log(x + ", " + y);
            // ----------------- VERY SHITTY ROOM GENERATION!!! ---------------------------
            //replace with code that will split off into different lines instead of going in a random line
            //use some recursive thing
            if (y < 0) { y = 0; }
            if (x < 0) { y = 25; x = 25; }
            while (Grid[x, y]) {
                if (!Grid[0, 0]) {
                    if (y > 0) { y--; } // go down if can't find a room
                    else if (x > 0) { x--; } // if at the top go to the left
                    Debug.Log(x + ", " + y);
                } else { // if zero zero is taken it means we are gona reset
                    if (y < 50) { y++; } 
                    else if (x < 50) { x++; } 
                }
            }

            if (x < 0 || y < 0 || x > 50 || y > 50) { break; }
            lastRoom = Instantiate(Room[0], new Vector3((x - 25) * 25, (y - 25) * 25, 100), Quaternion.Euler(0, 0, 0)); ;
            Grid[x, y] = lastRoom;
        }


        /*
        // -------------------- change me! -------------------------
        GameObject testR = Instantiate(Room[0], new Vector3(0, 0, 100), Quaternion.Euler(0,0,0));
        bool[] tempList = { false, false, true, false };
        testR.GetComponent<GateScript>().updateLocks(tempList);
        Instantiate(Room[0], new Vector3(0, 25, 100), Quaternion.Euler(0, 0, 0));
        Instantiate(Room[0], new Vector3(25, 0, 100), Quaternion.Euler(0, 0, 0));
        Instantiate(Room[0], new Vector3(0, -25, 100), Quaternion.Euler(0, 0, 0));

        Instantiate(Hall[0], new Vector3(0, 12.5f, 120), Quaternion.Euler(0, 0, 90));
        Instantiate(Hall[0], new Vector3(0, -12.5f, 120), Quaternion.Euler(0, 0, 90));
        Instantiate(Hall[0], new Vector3(12.5f, 0, 120), Quaternion.Euler(0, 0, 0));*/
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
