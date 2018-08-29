using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public float RotationSpeed;
    public float reload;
    public GameObject bullet;
    public Animator animations;
    public int numBullets;
    public float bulletSpray;
    public float knockBack;
    private float coolDown;
    private bool flipRender;

    // Use this for initialization
    void Start () {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(new Vector3(0, 0, RotationSpeed));
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(new Vector3(0, 0, -RotationSpeed));
        }
    }

    void Update() {
        if(transform.rotation.eulerAngles.z < 180) {
            if (flipRender) {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                flipRender = false;
            }
        } else {
            if (!flipRender) {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                flipRender = true;
            }
        }
    }

    public void Attack(Rigidbody2D player) {
        if (Time.time > coolDown) {
            animations.Play("Reload");
            for (int i = 0; i < numBullets; i++) {
                Quaternion sprayRot = Quaternion.Euler(0, 0, Random.Range(-bulletSpray, bulletSpray));
                Instantiate(bullet, transform.position, transform.rotation * sprayRot);
            }
            coolDown = Time.time + reload;
            Vector3 tran = new Vector3(0, -knockBack,0 );
            Debug.Log(tran);
            tran = transform.rotation * tran;
            
            player.AddForce(tran);
        }
    }
}
