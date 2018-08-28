using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public GameObject weapon;
    public float movementSpeed;
    private Rigidbody2D Rb;

	// Use this for initialization
	void Start () {
        Rb = GetComponent<Rigidbody2D>();
        weapon = Instantiate(weapon, transform);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        WeaponPickUpScript PU = collision.gameObject.GetComponent<WeaponPickUpScript>();
        Destroy(weapon);
        weapon = Instantiate(PU.getItem(), transform);
        Destroy(collision.gameObject);
    }
}
