using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float hp;
    public float movementSpeed = 0.01f;
    private Vector2 dir;
    private GameObject target;
    public Animator animations;

    // Use this for initialization
    void Start () {
        dir = new Vector2(0, 0.01f);
        transform.Translate(new Vector3(0, 0, -50));
	}
	
	// Update is called once per frame
	void Update () {
        //-----------------------------random movements---------------------------
        if (target) {
            float angel = Vector2.SignedAngle(transform.position - target.transform.position, Vector2.up);
            transform.Translate(Quaternion.Euler(0, 0, -angel) * new Vector2(0, -movementSpeed));
            // transform.Translate(Quaternion.Euler(0,0,  * new Vector2(0,1));
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        //-----------------------------hitting ally bullet-----------------------------
        if (collision.tag == "AllyDamage") {
            float damage = collision.gameObject.GetComponent<DamageScrpit>().Hit();
            Debug.Log(damage);
            hp -= damage;
            if(hp < 0) {
                animations.Play("Death");
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
