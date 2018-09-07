using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float hp;
    public float movementSpeed = 0.01f;
    public GameObject weapon;
    private Vector2 dir;
    private GameObject target;
    private Rigidbody2D Rb;
    public Animator animations;
    private WeaponScript weaponScript;

    // Use this for initialization
    void Start () {
        Rb = GetComponent<Rigidbody2D>();
        dir = new Vector2(0, 0.01f);
        transform.Translate(new Vector3(0, 0, -50));
        weaponScript = Instantiate(weapon, transform).GetComponent<WeaponScript>();
	}
	
	// Update is called once per frame
	void Update () {
        //-----------------------------random movements---------------------------
        if (target) {
            float angle = -Vector2.SignedAngle(transform.position - target.transform.position, Vector2.up);
            transform.Translate(Quaternion.Euler(0, 0, angle) * new Vector2(0, -movementSpeed));
            // transform.Translate(Quaternion.Euler(0,0,  * new Vector2(0,1));
            updateWeap(angle);
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
            if(hp < 0) {
                animations.Play("Death");
                Destroy(weaponScript.gameObject);
                Destroy(GetComponent<Collider2D>());
                Destroy(this);
                Destroy(gameObject,5);
            }
        }
    }

    public void setTarget(GameObject player) {
        target = player;
    }
}
