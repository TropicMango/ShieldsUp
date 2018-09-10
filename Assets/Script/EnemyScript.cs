using System.Collections;
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
            if(Time.time < dirDuration) {
                transform.Translate(dir * new Vector2(0, -movementSpeed));
            } else {
                dir = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
                dirDuration = Time.time + Random.Range(0.5f, 3f);
            }
        }
	}

    protected virtual void updateWeap(float angle) {
        weaponScript.setRotation(Quaternion.Euler(0, 0, 180 + angle));
        weaponScript.Attack(Rb);
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
            }
        }
    }

    public void initialize(GameObject player, GateScript RS) {
        target = player;
        this.RS = RS;
    }
}
