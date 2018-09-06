using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour {

    public BoxCollider2D[] gates;
    public GameObject[] enemies;
    private bool spawned = false;

    // Use this for initialization
    void Start () {
		
	}

    public void openTop(bool status) {
        gates[0].isTrigger = status;
    }
    public void openBot(bool status) {
        gates[1].isTrigger = status;
    }
    public void openLeft(bool status) {
        gates[2].isTrigger = status;
    }
    public void openRight(bool status) {
        gates[3].isTrigger = status;
    }

    public void spawnEnemies(GameObject player) {
        if (!spawned) {
            Debug.Log("GOT HIM!");
            for (int i = 0; i < enemies.Length; i++) {
                GameObject temp = Instantiate(enemies[i], transform.position, Quaternion.Euler(0, 0, 0));
                temp.GetComponent<EnemyScript>().setTarget(player);
            }
            spawned = true;
        }
    }
}
