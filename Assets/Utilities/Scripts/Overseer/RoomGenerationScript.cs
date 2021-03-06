﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerationScript : MonoBehaviour {

    // all of thse stand for the side you can exit
    public GameObject[] Room; 
    public GameObject[] Door; // Order: up, down, left, right
    public GameObject[] Hall; // Order: Horizontal, Vertical
    public GameObject[] enemies;
    public GameObject[] itemPedestal;
    public GameObject ProgressionToken;
    public CharacterUpdateScript CharacterManager;
    public GameManagerScript GameManager;
    public int numRooms = 10;
    private GameObject[,] Grid;
    private int size = 40;
    public int difficulty = 5;
    private List<GameObject> otherInstanciatedObjects;
    private float roomDist = 25;

    private void Start() {
        Grid = new GameObject[size, size];
        otherInstanciatedObjects = new List<GameObject>();
        startingSequence();
    }

    private void startingSequence() {
        SmartGeneration(numRooms, size / 2, size / 2, -100);
        
        float pedestalDistance = 2.5f;
        for (int i = 0; i < 5; i++) {
            GameObject IP = Instantiate(itemPedestal[i], new Vector3(pedestalDistance * Mathf.Sin(2*Mathf.PI/ 5*i), pedestalDistance * Mathf.Cos(2 * Mathf.PI / 5 * i), 15), Quaternion.Euler(0, 0, 0));
            IP.transform.SetParent(this.transform);
            IP.GetComponent<pedestalScript>().setManager(CharacterManager, this, GameManager);
            otherInstanciatedObjects.Add(IP);
        }

        pedestalDistance += 2.5f;

        for (int i = 0; i < itemPedestal.Length-5; i++) {
            GameObject IP = Instantiate(itemPedestal[i+5], new Vector3(pedestalDistance * Mathf.Sin(2 * Mathf.PI / (itemPedestal.Length-5) * i), pedestalDistance * Mathf.Cos(2 * Mathf.PI / (itemPedestal.Length-5) * i), 15), Quaternion.Euler(0, 0, 0));
            IP.transform.SetParent(this.transform);
            IP.GetComponent<pedestalScript>().setManager(CharacterManager, this, GameManager);
            otherInstanciatedObjects.Add(IP);
        }
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
                default:
                    dir = Random.Range(0, 3);
                    break;
            }
        }

        // summon room
        GameObject new_room = Instantiate(Room[0], new Vector3((roomX - size / 2) * roomDist, (roomY - size / 2) * roomDist, 120), Quaternion.Euler(0, 0, 0));
        new_room.transform.SetParent(this.transform);
        Grid[roomX, roomY] = new_room;
        if (roomsLeft != numRooms && roomsLeft != 1) {
            addEnemies(Grid[roomX, roomY].GetComponent<GateScript>());
        }else if (roomsLeft == 1) {
            GameObject PT = Instantiate(ProgressionToken, new Vector3((roomX - size / 2) * roomDist, (roomY - size / 2) * roomDist, 90), Quaternion.Euler(0, 0, 0));
            PT.transform.SetParent(this.transform);
            PT.GetComponent<ProgressionTokenScript>().setGeneratorScript(this);
            otherInstanciatedObjects.Add(PT);
        }

        GameObject new_hall;
        switch (dir) { // Open the gates on for the rooms and create the hall
            case 0:
                Grid[roomX, roomY - 1].GetComponent<GateScript>().openTop(true);
                Grid[roomX, roomY].GetComponent<GateScript>().openBot(true);
                new_hall = Instantiate(Hall[0], new Vector3((roomX - size / 2) * roomDist, (roomY - size / 2) * roomDist - roomDist/2, 100), Quaternion.Euler(0, 0, 90));
                new_hall.transform.SetParent(this.transform);
                otherInstanciatedObjects.Add(new_hall);
                break;
            case 1:
                Grid[roomX, roomY + 1].GetComponent<GateScript>().openBot(true);
                Grid[roomX, roomY].GetComponent<GateScript>().openTop(true);
                new_hall = Instantiate(Hall[0], new Vector3((roomX - size / 2) * roomDist, (roomY - size / 2) * roomDist + roomDist/2, 100), Quaternion.Euler(0, 0, 90));
                new_hall.transform.SetParent(this.transform);
                otherInstanciatedObjects.Add(new_hall);
                break;
            case 2:
                Grid[roomX + 1, roomY].GetComponent<GateScript>().openLeft(true);
                Grid[roomX, roomY].GetComponent<GateScript>().openRight(true);
                new_hall = Instantiate(Hall[0], new Vector3((roomX - size / 2) * roomDist + roomDist/2, (roomY - size / 2) * roomDist, 100), Quaternion.Euler(0, 0, 0));
                new_hall.transform.SetParent(this.transform);
                otherInstanciatedObjects.Add(new_hall);
                break;
            case 3:
                Grid[roomX - 1, roomY].GetComponent<GateScript>().openRight(true);
                Grid[roomX, roomY].GetComponent<GateScript>().openLeft(true);
                new_hall = Instantiate(Hall[0], new Vector3((roomX - size / 2) * roomDist - roomDist/2, (roomY - size / 2) * roomDist, 100), Quaternion.Euler(0, 0, 0));
                new_hall.transform.SetParent(this.transform);
                otherInstanciatedObjects.Add(new_hall);
                break;
        }

        // int repeats = Random.Range(1, 3);
        // repeats = (roomsLeft > repeats) ? repeats : roomsLeft;
        int repeats = 1;
        for (int i = 0; i < repeats; i++) {
            roomsLeft -= 1;
            switch (Random.Range(0, 3)) { // calls it self for new rooms
                case 0:
                    if (roomY < size) {
                        SmartGeneration(roomsLeft, roomX, roomY + 1, 0);
                    } else {
                        SmartGeneration(roomsLeft, roomX, roomY - 1, 1);
                    }
                    break;
                case 1:
                    if (roomY > 0) {
                        SmartGeneration(roomsLeft, roomX, roomY - 1, 1);
                    } else {
                        SmartGeneration(roomsLeft, roomX, roomY + 1, 0);
                    }
                    break;
                case 2:
                    if (roomX > 0) {
                        SmartGeneration(roomsLeft, roomX - 1, roomY, 2);
                    } else {
                        SmartGeneration(roomsLeft, roomX + 1, roomY, 3);
                    }
                    break;
                case 3:
                    if (roomX < 0) {
                        SmartGeneration(roomsLeft, roomX + 1, roomY, 3);
                    } else {
                        SmartGeneration(roomsLeft, roomX - 1, roomY, 2);
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

    public void progression() {
        for(int i=0; i<size; i++) {
            for (int j = 0; j < size; j++) {
                if (Grid[i, j]) {
                    Destroy(Grid[i, j]);
                    Grid[i, j] = null;
                }
            }
        }
        for(int i=otherInstanciatedObjects.Count-1; i>=0; i--) {
            if (otherInstanciatedObjects[i]) {
                otherInstanciatedObjects[i].GetComponent<Removable>().remove();
            }
            otherInstanciatedObjects.RemoveAt(i);
        }
        Debug.Log("---------------------");
        numRooms++;
        difficulty++;
        SmartGeneration(numRooms, size/2, size/2, -100);
    }
}
