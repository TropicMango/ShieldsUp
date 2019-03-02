using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStyleGenerationScript : MonoBehaviour
{
    public GameObject[] Room;
    public GameObject gate;
    public GameObject[] Enemies;
    public int roomDist = 20;

    private GameObject[,] Grid;
    private int size = 40;
    void Start()
    {
        // start generation
        Grid = new GameObject[size, size];
        generate_rooms(size/2, size/2);
    }

    void generate_rooms(int x, int y) {
        GameObject new_room = Instantiate(Room[0], new Vector3((x - size / 2) * roomDist, (y - size / 2) * roomDist, 0), Quaternion.Euler(0, 0, 0));
        Grid[x, y] = new_room;

    }

}
