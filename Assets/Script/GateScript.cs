using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour {

    public BoxCollider2D[] gates;
    private List<GameObject> enemies;
    private bool spawned = true;

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

    public void addMonsters(List<GameObject> enemy) {
        enemies = enemy;
        spawned = false;
    }

    private float range = 8;
    public void spawnEnemies(GameObject player) {
        if (!spawned) {
            for (int i = 0; i < enemies.Count; i++) {
                GameObject temp = Instantiate(enemies[i], transform.position + new Vector3(Random.Range(-range, range), Random.Range(-range, range)), Quaternion.Euler(0, 0, 0));
                temp.GetComponent<EnemyScript>().setTarget(player);
            }
            spawned = true;
        }
    }
}
