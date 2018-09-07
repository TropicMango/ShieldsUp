using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerationScript : MonoBehaviour {

    // all of thse stand for the side you can exit
    public GameObject[] Room; 
    public GameObject[] Door; // Order: up, down, left, right
    public GameObject[] Hall; // Order: Horizontal, Vertical
    public GameObject[] enemies;
    public int numRooms = 10;
    private GameObject[,] Grid;
    private int size = 40;
    private int difficulty = 5;


    private void Start() {
        Grid = new GameObject[size, size];
        SmartGeneration(numRooms, size / 2, size / 2, -100);
    }

    void SmartGeneration(int roomsLeft, int roomX, int roomY, int dir) {
        if(roomsLeft == 0) { return; } // Kinda Recursive but also is basically just a while loop XD

        while (Grid[roomX, roomY]) { // if current room is taken keep on going in the same direction
            switch (dir) {
                case 0:
                    roomY += 1;
                    break;
                case 1:
                    roomY -= 1;
                    break;
                case 2:
                    roomX -= 1;
                    break;
                case 3:
                    roomX += 1;
                    break;
            }
        }

        // summon room
        Grid[roomX, roomY] = Instantiate(Room[0], new Vector3((roomX - size / 2) * 25, (roomY - size / 2) * 25, 100), Quaternion.Euler(0, 0, 0)); ;
        if (roomsLeft != numRooms && roomsLeft != 1) {
            addEnemies(Grid[roomX, roomY].GetComponent<GateScript>());
        }

        switch (dir) { // Open the gates on for the rooms and create the hall
            case 0:
                Grid[roomX, roomY-1].GetComponent<GateScript>().openTop(true);
                Grid[roomX, roomY].GetComponent<GateScript>().openBot(true);
                Instantiate(Hall[0], new Vector3((roomX - size / 2) * 25, (roomY - size / 2) * 25 - 12.5f, 120), Quaternion.Euler(0, 0, 90));
                break;
            case 1:
                Grid[roomX, roomY + 1].GetComponent<GateScript>().openBot(true);
                Grid[roomX, roomY].GetComponent<GateScript>().openTop(true);
                Instantiate(Hall[0], new Vector3((roomX - size / 2) * 25, (roomY - size / 2) * 25 + 12.5f, 120), Quaternion.Euler(0, 0, 90));
                break;
            case 2:
                Grid[roomX + 1, roomY].GetComponent<GateScript>().openLeft(true);
                Grid[roomX, roomY].GetComponent<GateScript>().openRight(true);
                Instantiate(Hall[0], new Vector3((roomX - size / 2) * 25 + 12.5f, (roomY - size / 2) * 25, 120), Quaternion.Euler(0, 0, 0));
                break;
            case 3:
                Grid[roomX - 1, roomY].GetComponent<GateScript>().openRight(true);
                Grid[roomX, roomY].GetComponent<GateScript>().openLeft(true);
                Instantiate(Hall[0], new Vector3((roomX - size / 2) * 25 - 12.5f, (roomY - size / 2) * 25, 120), Quaternion.Euler(0, 0, 0));
                break;
        }

        int repeats = Random.Range(1, 1);

        for (int i = 0; i < repeats; i++) {
            switch (Random.Range(0, 3)) { // calls it self for new rooms
                case 0:
                    if (roomY < size) {
                        SmartGeneration(roomsLeft - 1, roomX, roomY + 1, 0);
                    } else {
                        SmartGeneration(roomsLeft - 1, roomX, roomY - 1, 1);
                    }
                    break;
                case 1:
                    if (roomY > 0) {
                        SmartGeneration(roomsLeft - 1, roomX, roomY - 1, 1);
                    } else {
                        SmartGeneration(roomsLeft - 1, roomX, roomY + 1, 0);
                    }
                    break;
                case 2:
                    if (roomX > 0) {
                        SmartGeneration(roomsLeft - 1, roomX - 1, roomY, 2);
                    } else {
                        SmartGeneration(roomsLeft - 1, roomX + 1, roomY, 3);
                    }
                    break;
                case 3:
                    if (roomX < 0) {
                        SmartGeneration(roomsLeft - 1, roomX + 1, roomY, 3);
                    } else {
                        SmartGeneration(roomsLeft - 1, roomX - 1, roomY, 2);
                    }
                    break;
            }
        }

    }

    void addEnemies(GateScript room) {
        List<GameObject> monsters = new List<GameObject>();
        for (int i=0; i<difficulty; i++) {
            monsters.Add(enemies[Random.Range(0, enemies.Length)]);
        }
        room.addMonsters(monsters);
    }
}
