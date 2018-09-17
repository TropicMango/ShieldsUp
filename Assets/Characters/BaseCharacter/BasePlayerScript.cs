using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerScript : PlayerScript {


    // Use this for initialization
    void Start() {
        Rb = GetComponent<Rigidbody2D>();
        //Instantiate(camera, transform);
    }

    // Update is called once per frame
    void FixedUpdate() {
        // -------------------- basic movement --------------------------
        ani.speed = 1;
        if (Input.GetKey(KeyCode.W)) {
            Rb.AddForce(new Vector2(0, movementSpeed));
            ani.speed = movementSpeed / 5 + 1;
        } else if (Input.GetKey(KeyCode.S)) {
            Rb.AddForce(new Vector2(0, -1 * movementSpeed));
            ani.speed = movementSpeed / 5 + 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            Rb.AddForce(new Vector2(-1 * movementSpeed, 0));
            ani.speed = movementSpeed / 5 + 1;
        } else if (Input.GetKey(KeyCode.D)) {
            Rb.AddForce(new Vector2(movementSpeed, 0));
            ani.speed = movementSpeed / 5 + 1;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            ShieldsUp();
        }
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.tag == "Pedestal") {
            collision.gameObject.GetComponent<pedestalScript>().pickUp(this);
        }
    }
}
