using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerScript : PlayerScript {


    // Use this for initialization
    void Start() {
        Rb = GetComponent<Rigidbody2D>();
        //Instantiate(camera, transform);
    }

    override
    protected  void updateWeapon() {
        if (Rb.velocity.x > 0) {
            updatePlayerSprite(true);
        } else {
            updatePlayerSprite(false);
        }
    }



    private void OnTriggerEnter(Collider collision) {
        if (collision.tag == "Pedestal") {
            collision.gameObject.GetComponent<pedestalScript>().pickUp(this);
        }
    }
}
