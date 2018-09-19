using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour {

    public BoxCollider2D[] gates;
    private List<GameObject> enemies;
    public GameObject portal;
    private bool spawned = true;
    private bool[] gateUsed= {false, false, false, false };
    private int numEnemies = 0;

    void Start () {
    }

    public void openTop(bool status) {
        gates[0].enabled = !status;
        gateUsed[0] = status;
    }
    public void openBot(bool status) {
        gates[1].enabled = !status;
        gateUsed[1] = status;
    }
    public void openLeft(bool status) {
        gates[2].enabled = !status;
        gateUsed[2] = status;
    }
    public void openRight(bool status) {
        gates[3].enabled = !status;
        gateUsed[3] = status;
    }

    public void addMonsters(List<GameObject> enemy) {
        enemies = enemy;
        spawned = false;
        numEnemies += enemy.Count;
    }

    public void allyDied() {
        Debug.Log(numEnemies);
        numEnemies--;
        if(numEnemies <= 0) {
            for (int i = 0; i < gates.Length; i++) {
                gates[i].isTrigger = gateUsed[i];
            }
        }
    }

    private float range = 8;
    public void spawnEnemies(GameObject player) {
        if (!spawned) {
            for (int i = 0; i < enemies.Count; i++) {
                GameObject temp = Instantiate(portal, transform.position + new Vector3(Random.Range(-range, range), Random.Range(-range, range)), Quaternion.Euler(0, 0, 0));
                temp.GetComponent<SummoningPortal>().initialize(enemies[i], player, this);
            }
            spawned = true;
            for(int i=0; i < gates.Length; i++) {
                gates[i].enabled = true;
            }
        }
    }
}
