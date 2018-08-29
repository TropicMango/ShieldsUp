using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private Vector2 dir;

	// Use this for initialization
	void Start () {
        dir = new Vector2(0, 0.01f);
	}
	
	// Update is called once per frame
	void Update () {
        //-----------------------------random movements-----------------------------
        if (Random.Range(0, 10) < 1) {
            dir = new Vector2(0, -1 * dir.y);
        }
        transform.Translate(dir);
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        //-----------------------------hitting ally bullet-----------------------------
        if (collision.tag == "AllyDamage") {
            float damage = collision.gameObject.GetComponent<DamageScrpit>().Hit();
            Debug.Log(damage);
        }
    }
}
