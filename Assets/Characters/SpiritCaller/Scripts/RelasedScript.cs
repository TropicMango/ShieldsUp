using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelasedScript : BulletScrpit {
    private Quaternion dir;
    private GateScript gate;
    private GameObject target;

	// Use this for initialization
	void Start () {
        // dir = Quaternion.Euler(0, 0, Random.Range(0, 360));
        transform.rotation = Quaternion.Euler(0, 0, 0);
        setStats(10, 0.1f, 1000, 0);
	}

    public void setGate(GateScript gate) {
        this.gate = gate;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (target && target.tag == "Enemy") {
            if (Vector2.Distance(transform.position, target.transform.position) < movementSpeed) {
                target.GetComponent<EnemyScript>().recieveDamage(1);
                transform.position = target.transform.position;
            } else {
                float angle = -Vector2.SignedAngle(transform.position - target.transform.position, Vector2.up);
                transform.Translate(Quaternion.Euler(0, 0, angle) * new Vector2(0, -movementSpeed));
            }
        } else {
            List<GameObject> Elist = gate.getEnemies();
            if (Elist.Count > 0) {
                /*for (int i = 0; i < Elist.Count; i++) {
                    if (Elist[i].tag == "Enemy") {
                        target = Elist[i];
                        break;
                    }
                }*/
                target = Elist[Random.Range(0,Elist.Count)];
            } else {
                Destroy(gameObject);
            }
        }
    }
}
