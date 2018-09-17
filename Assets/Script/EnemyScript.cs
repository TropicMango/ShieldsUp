﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float hp;
    public float movementSpeed = 0.01f;
    public GameObject weapon;
    private Quaternion dir;
    private float dirDuration;
    private GameObject target;
    private Rigidbody2D Rb;
    public Animator animations;
    public float attackRange;
    private WeaponScript weaponScript;
    private GateScript RS;
    public SpriteRenderer spriteRenderer;
    public bool melee;
    protected float coolDown;
    public float reload;

    // Use this for initialization
    void Start () {
        Rb = GetComponent<Rigidbody2D>();
        dir = new Quaternion(0,0,0,0);
        transform.Translate(new Vector3(0, 0, -50));
        weaponScript = Instantiate(weapon, transform).GetComponent<WeaponScript>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //-----------------------------random movements---------------------------
        if (target) {
            float angle = -Vector2.SignedAngle(transform.position - target.transform.position, Vector2.up);
            updateWeap(angle);
            if (melee) {
                transform.Translate(Quaternion.Euler(0,0,angle) * new Vector2(0, -movementSpeed));
            } else {
                if (Time.time < dirDuration) {
                    transform.Translate(dir * new Vector2(0, -movementSpeed));
                } else {
                    dir = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
                    dirDuration = Time.time + Random.Range(0.5f, 3f);
                }
            }
        }
	}

    protected virtual void updateWeap(float angle) {
        weaponScript.setRotation(Quaternion.Euler(0, 0, 180 + angle));
        if (Time.time > coolDown) {
            coolDown = Time.time + reload;
            weaponScript.Attack(Rb);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        //-----------------------------hitting ally bullet-----------------------------
        if (collision.tag == "AllyDamage") {
            float damage = collision.gameObject.GetComponent<DamageScrpit>().Hit();
            Debug.Log(damage);
            hp -= damage;
            if(hp < 0 && hp != -123) {
                hp = -123;
                animations.Play("Death");
                RS.allyDied();
                Destroy(weaponScript.gameObject);
                Destroy(GetComponent<Collider2D>());
                Destroy(this);
                Destroy(gameObject,5);
            } else {
                StartCoroutine(damageFlash());
            }
        }
    }

    IEnumerator damageFlash() {
        for (int i = 0; i < 5; i++) {
            spriteRenderer.color = new Color(1f, 1f, 1f, .2f);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void initialize(GameObject player, GateScript RS) {
        target = player;
        this.RS = RS;
    }
}
