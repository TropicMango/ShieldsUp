using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    //public Camera camera;
    public GameObject weapon;
    public GameObject Shield;
    public float movementSpeed;
    public float abilityRecharge;
    protected float abilityCoolDown;
    private Rigidbody2D Rb;
    private WeaponScript weaponS;

    // Use this for initialization
    void Start() {
        Rb = GetComponent<Rigidbody2D>();
        weapon = Instantiate(weapon, transform);
        weaponS = weapon.GetComponent<WeaponScript>();
        //Instantiate(camera, transform);
    }

    // Update is called once per frame
    void FixedUpdate() {
        // -------------------- basic movement --------------------------
        if (Input.GetKey(KeyCode.W)) {
            Rb.AddForce(new Vector2(0, movementSpeed));
        } else if (Input.GetKey(KeyCode.S)) {
            Rb.AddForce(new Vector2(0, -1 * movementSpeed));
        }
        if (Input.GetKey(KeyCode.A)) {
            Rb.AddForce(new Vector2(-1 * movementSpeed, 0));
        } else if (Input.GetKey(KeyCode.D)) {
            Rb.AddForce(new Vector2(movementSpeed, 0));
        }

        //-----------------------------rotation of weapon-----------------------------
        if (Input.GetKey(KeyCode.LeftArrow)) {
            weaponS.rotateLeft();
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            weaponS.rotateRight();
        }

        // ------------------- other player input ----------------------
        if (Input.GetKey(KeyCode.Space)) {
            Attack();
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            ActivateAbility();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            ShieldsUp();
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
            SwapWeap(collision.gameObject.GetComponent<WeaponPickUpScript>().getItem(weapon));
            // Destroy(collision.gameObject);
        } else if (collision.tag == "AllyUpgrade") {
            collision.gameObject.GetComponent<UpgradePickUpScript>().upgrade(this);
        } else if (collision.tag == "Room") {
            collision.gameObject.GetComponent<GateScript>().spawnEnemies(gameObject);
        }
    }

    public virtual void ActivateAbility() {
        if (Time.time > abilityCoolDown) {
            weaponS.Activate(Rb);
            abilityCoolDown = Time.time + abilityRecharge;
        }
    }

    public virtual void ShieldsUp() {
        Destroy(Instantiate(Shield, transform), 0.5f);
    }

    public virtual void Attack() {
        weaponS.Attack(Rb); // tranform is passed for knock back
    }
}
