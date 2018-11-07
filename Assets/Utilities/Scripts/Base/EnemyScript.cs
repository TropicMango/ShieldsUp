using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : CharacterScript {

    private Quaternion dir;
    private float dirDuration;
    private GameObject target;
    public Animator animations;
    public float attackRange;
    private WeaponScript weaponScript;
    private GateScript RS;
    public bool melee;
    protected float coolDown;
    public float reload;

    // Use this for initialization
    void Start () {
        dir = new Quaternion(0,0,0,0);
        transform.Translate(new Vector3(0, 0, -50));
        weaponScript = Instantiate(weapon, transform).GetComponent<WeaponScript>();
        weaponScript.init(gameObject, false);
        coolDown = Time.time + Random.Range(0, reload);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (stunned) { return; }
        //-----------------------------random movements---------------------------
        if (target) {
            float angle = -Vector2.SignedAngle(transform.position - target.transform.position, Vector2.up);
            updateWeap(angle);
            if (melee) {
                if (Time.time < dirDuration) {
                    transform.Translate(dir * new Vector2(0, -movementSpeed));
                } else {
                    dir = Quaternion.Euler(0, 0, angle + Random.Range(-40f, 40f));
                    dirDuration = Time.time + Random.Range(0.5f, 3f);
                }
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
        spriteRenderer.flipX = weaponScript.setRotation(Quaternion.Euler(0, 0, 180 + angle));
        if (Time.time > coolDown && Vector2.Distance(target.transform.position, transform.position) < attackRange) {
            coolDown = Time.time + reload;
            weaponScript.checkAttack();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        //-----------------------------hitting ally bullet-----------------------------
        if (collision.tag == "AllyDamage") {
            float damage = collision.gameObject.GetComponent<DamageScrpit>().Hit(gameObject);
            // Debug.Log(damage);
            recieveDamage(damage);
        }else if (collision.tag == "Special") {
            collision.GetComponent<EffectCircle>().triggerEffect(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Special") {
            collision.GetComponent<EffectCircle>().exitEffect(gameObject);
        }
    }

    override
    public void recieveDamage(float damage) {
        hp -= damage;
        Debug.Log(damage);
        if (hp < 0 && hp != -123) {
            hp = -123;
            animations.Play("Death");
            RS.allyDied(gameObject);
            spriteRenderer.color = new Color(1f, 1f, 1f, .2f);
            gameObject.tag = "Dead";
            Destroy(weaponScript.gameObject);
            Destroy(GetComponent<Collider2D>());
            Destroy(this);
            Destroy(gameObject, 5);
        } else {
            StartCoroutine(damageFlash());
        }
    }

    IEnumerator damageFlash() {
        for (int i = 0; i < 1; i++) {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a * 0.2f);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void initialize(GameObject player, GateScript RS) {
        target = player;
        this.RS = RS;
    }
}
