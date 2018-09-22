using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : CharacterScript {
    
    public string characterClass;

    protected float currentHp;
    public Animator ani;
    public GameObject CharacterSprite;
    public GameObject Shield;
    protected Rigidbody2D Rb;
    protected WeaponScript weaponScript;
    protected OverlayScript cam;

    // Use this for initialization
    void Start() {
        Rb = GetComponent<Rigidbody2D>();
        weaponScript = Instantiate(weapon,transform).GetComponent<WeaponScript>();
        weaponScript.init(gameObject, true);
        currentHp = hp;
        initialize();
    }

    protected virtual void initialize() { }

    // Update is called once per frame
    void FixedUpdate() {
        updateMovement();
        updateWeapon();
        updateOther();
    }

    protected virtual void updateMovement() {
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
    }

    protected virtual void updateWeapon() {
        //-----------------------------rotation of weapon-----------------------------
        if (Input.GetKey(KeyCode.LeftArrow)) {
            if (Input.GetKey(KeyCode.UpArrow)) {
                updatePlayerSprite(weaponScript.rotateAngle(45)); // top left
            } else if (Input.GetKey(KeyCode.DownArrow)) {
                updatePlayerSprite(weaponScript.rotateAngle(135)); // bot left
            } else {
                updatePlayerSprite(weaponScript.rotateAngle(90)); // left
            }
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            if (Input.GetKey(KeyCode.UpArrow)) {
                updatePlayerSprite(weaponScript.rotateAngle(315)); // top right
            } else if (Input.GetKey(KeyCode.DownArrow)) {
                updatePlayerSprite(weaponScript.rotateAngle(225)); // bot right
            } else {
                updatePlayerSprite(weaponScript.rotateAngle(270)); // right
            }
        } else if (Input.GetKey(KeyCode.UpArrow)) {
            updatePlayerSprite(weaponScript.rotateAngle(0)); // top
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            updatePlayerSprite(weaponScript.rotateAngle(180)); // bot
        }
    }

    protected virtual void updateOther() {
        // ------------------- other player input ----------------------
        Attack();
        ActivateAbility();
        ShieldsUp();
    }

    public virtual void ActivateAbility() {
        if (Input.GetKey(KeyCode.Q)) {
            weaponScript.checkActivation();
        }
    }

    public virtual void ShieldsUp() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Destroy(Instantiate(Shield, transform), 0.5f);
        }
    }

    public virtual void Attack() {
        if (Input.GetKey(KeyCode.Space)) {
            weaponScript.checkAttack();
        }
        // tranform is passed for knock back
    }

    protected void updatePlayerSprite(bool flip) {
        if (flip) {
            CharacterSprite.transform.localScale = new Vector3(-Mathf.Abs(CharacterSprite.transform.localScale.x), CharacterSprite.transform.localScale.y, CharacterSprite.transform.localScale.z);
        } else {
            CharacterSprite.transform.localScale = new Vector3(Mathf.Abs(CharacterSprite.transform.localScale.x), CharacterSprite.transform.localScale.y, CharacterSprite.transform.localScale.z);
        }
    }

    private void Update() {
        cam.updateAbility(weaponScript.abilityRecharge, weaponScript.getAbilityCoolDown() - Time.time);
    }

    public WeaponScript GetWeaponScript() {
        return weaponScript;
    }

    public void setUI(OverlayScript camera) {
        Debug.Log("camera set");
        this.cam = camera;
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
        }else if(collision.tag == "Pedestal") {
            collision.gameObject.GetComponent<pedestalScript>().pickUp(this);
        }else if (collision.tag == "Room") {
            collision.gameObject.GetComponent<GateScript>().spawnEnemies(gameObject);
        }
        extraTriggernEnter(collision.gameObject);
    }

    protected virtual void extraTriggernEnter(GameObject colli) {
        // override me
    }

    protected void hurt(float damage) {
        StartCoroutine(cam.shake(damage));
        currentHp -= damage;
        cam.updateHP(hp, currentHp);
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
}
