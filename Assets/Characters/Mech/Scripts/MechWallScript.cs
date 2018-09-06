using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechWallScript : MonoBehaviour {

    private float hp = 100;


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "EnemyDamage") {
            hp -= collision.gameObject.GetComponent<BulletScrpit>().Hit();
            if(hp < 0) {
                Destroy(gameObject);
            }
        }
    }
}
