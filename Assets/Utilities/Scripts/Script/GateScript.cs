using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour {

    public BoxCollider2D[] gates;
    public GameObject GateSprite;
    private List<GameObject> enemies;
    private List<GameObject> generatedEnemies;
    public GameObject portal;
    private bool spawned = true;
    private bool[] gateUsed = { false, false, false, false };
    // public int numEnemies = 0;
    private GameObject[] gateSprites = {null, null, null, null};

    private void Start() {
        generatedEnemies = new List<GameObject>(); 
    }

    public void openTop(bool status) {
        gates[0].isTrigger = status;
        gateUsed[0] = status;
    }
    public void openBot(bool status) {
        gates[1].isTrigger = status;
        gateUsed[1] = status;
    }
    public void openLeft(bool status) {
        gates[2].isTrigger = status;
        gateUsed[2] = status;
    }
    public void openRight(bool status) {
        gates[3].isTrigger = status;
        gateUsed[3] = status;
    }

    public void addMonsters(List<GameObject> enemy) {
        enemies = enemy;
        spawned = false;
    }

    public void allyDied(GameObject EN) {
        generatedEnemies.Remove(EN);
        // numEnemies--;
        if (generatedEnemies.Count == 0) {
            for (int i = 0; i < gates.Length; i++) {
                gates[i].isTrigger = gateUsed[i];
                Destroy(gateSprites[i]);
                
            }
        }
    }


    private IEnumerator summonEnemy(int i, GameObject player, Vector3 tempPos) {
        yield return new WaitForSeconds(3);
        // numEnemies ++;
        GameObject tempEnemy = Instantiate(enemies[i], transform.position + tempPos, Quaternion.Euler(0, 0, 0));
        tempEnemy.GetComponent<EnemyScript>().initialize(player, this);
        generatedEnemies.Add(tempEnemy);
    }

    public List<GameObject> getEnemies() {
        return generatedEnemies;
    }

    private float range = 8;
    public void spawnEnemies(GameObject player) {
        if (!spawned) {
            for (int i = 0; i < enemies.Count; i++) {
                Vector3 tempPos = new Vector3(Random.Range(-range, range), Random.Range(-range, range));
                Destroy( Instantiate(portal, transform.position + tempPos + new Vector3(0, 0, -10), Quaternion.Euler(0, 0, 0)),3);
                StartCoroutine(summonEnemy(i, player, tempPos));
            }
            spawned = true;

            if (gateUsed[0]) {
                gateSprites[0] = Instantiate(GateSprite, transform.position + new Vector3(0, 9.23f, -21), Quaternion.Euler(0, 0, 90));
            }
            if (gateUsed[1]) {
                gateSprites[1] = Instantiate(GateSprite, transform.position + new Vector3(0, -9.23f, -21), Quaternion.Euler(0, 0, -90));
            }
            if (gateUsed[2]) {
                gateSprites[2] = Instantiate(GateSprite, transform.position + new Vector3(-9.23f, 0, -21), Quaternion.Euler(0, 0, 180));
            }
            if (gateUsed[3]) {
                gateSprites[3] = Instantiate(GateSprite, transform.position + new Vector3(9.23f, 0, -21), Quaternion.Euler(0, 0, 0));
            }
        }
    }
}