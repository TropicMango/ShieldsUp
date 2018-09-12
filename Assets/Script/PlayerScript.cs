using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private OverlayScript camera;
    public float maxHp;
    private float currentHp;
    public GameObject weapon;
    public GameObject Shield;
    public float movementSpeed;
    public float reload;
    protected float coolDown;
    public float abilityRecharge;
    protected float abilityCoolDown;
    private Rigidbody2D Rb;
    private WeaponScript weaponScript;

    // Use this for initialization
    void Start() {
        Rb = GetComponent<Rigidbody2D>();
        weapon = Instantiate(weapon, transform);
        weaponScript = weapon.GetComponent<WeaponScript>();
        weaponScript.init(true);
        currentHp = maxHp;
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
            weaponScript.rotateLeft();
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            weaponScript.rotateRight();
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

    private void Update() {
        camera.updateAbility(abilityRecharge, abilityCoolDown - Time.time);
    }

    //no longer being used due to the class system
    /*
    void SwapWeap(GameObject weap) {
        // -------------------- deletes current weap & swap --------------------------
        Quaternion weapRot = weapon.transform.rotation;
        Destroy(weapon);
        weapon = Instantiate(weap, transform);
        weapon.transform.rotation = weapRot;
        weaponS = weapon.GetComponent<WeaponScript>();
    }*/

    public void setUI(OverlayScript camera) {
        this.camera = camera;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Pickup") {
            // SwapWeap(collision.gameObject.GetComponent<WeaponPickUpScript>().getItem(weapon));
            // Destroy(collision.gameObject);
        } else if (collision.tag == "AllyUpgrade") {
            collision.gameObject.GetComponent<UpgradePickUpScript>().upgrade(this);
        } else if (collision.tag == "EnemyDamage") {
            hurt(collision.gameObject.GetComponent<BulletScrpit>().Hit());
        } else if(collision.tag == "Token") {
            collision.gameObject.GetComponent<ProgressionTokenScript>().progress(gameObject);
        }
    }

    protected void hurt(float damage) {
        StartCoroutine(camera.shake());
        currentHp -= damage;
        camera.updateHP(maxHp, currentHp);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Room") {
            collision.gameObject.GetComponent<GateScript>().spawnEnemies(gameObject);
        }
    }

    public virtual void ActivateAbility() {
        if (Time.time > abilityCoolDown) {
            weaponScript.Activate(Rb);
            abilityCoolDown = Time.time + abilityRecharge;
        }
    }

    public virtual void ShieldsUp() {
        Destroy(Instantiate(Shield, transform), 0.5f);
    }

    public virtual void Attack() {
        if (Time.time > coolDown) {
            coolDown = Time.time + reload;
            weaponScript.Attack(Rb); // tranform is passed for knock back
        }
    }
}
