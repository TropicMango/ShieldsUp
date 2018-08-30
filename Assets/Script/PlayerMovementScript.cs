using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public GameObject weapon;
    public float movementSpeed;
    private Rigidbody2D Rb;
    private WeaponScript weaponS;

	// Use this for initialization
	void Start () {
        Rb = GetComponent<Rigidbody2D>();
        weapon = Instantiate(weapon, transform);
        weaponS = weapon.GetComponent<WeaponScript>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        // -------------------- basic movement --------------------------
        if (Input.GetKey(KeyCode.W)){
            Rb.AddForce(new Vector2(0, movementSpeed));
        } else if (Input.GetKey(KeyCode.S)){
            Rb.AddForce(new Vector2(0, -1*movementSpeed));
        }
        if (Input.GetKey(KeyCode.A)) {
            Rb.AddForce(new Vector2(-1*movementSpeed, 0));
        } else if (Input.GetKey(KeyCode.D)) {
            Rb.AddForce(new Vector2(movementSpeed, 0));
        }
        if (Input.GetKey(KeyCode.Space)) {
            weaponS.Attack(Rb); // tranform is passed for knock back
        }
    }

    void SwapWeap(GameObject weap) {
        // -------------------- deletes current weap & swap --------------------------
        Quaternion weapRot = weapon.transform.rotation;
        Destroy(weapon);
        weapon = Instantiate(weap, transform);
        weapon.transform.rotation = weapRot;
        weaponS = weapon.GetComponent<WeaponScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Pickup") {
            SwapWeap(collision.gameObject.GetComponent<WeaponPickUpScript>().getItem());
            // Destroy(collision.gameObject);
        }
    }
}
