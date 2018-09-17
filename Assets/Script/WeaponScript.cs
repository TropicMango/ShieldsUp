using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public float RotationSpeed;
    public float terminationTime;
    public GameObject bullet;
    public Animator animations;
    public int numBullets;
    public float delay;
    public float bulletSpray;
    public float knockBack;
    public float bonusBulletSize;
    public float damage;
    // private bool flipRender = true;
    private bool isPlayer = false;
    public bool melee;
    private float rotationLock;


    public void init(bool isPlayer) {
        this.isPlayer = isPlayer;
    }

    private bool flip() {
        if (transform.rotation.eulerAngles.z < 180) {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            return false;
        } else {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            return true;
        }

    }

    public bool rotateLeft() {
        if (Time.time > rotationLock) {
            transform.Rotate(new Vector3(0, 0, RotationSpeed));
        }
        return flip();
    }

    public bool rotateRight() {
        if (Time.time > rotationLock) {
            transform.Rotate(new Vector3(0, 0, -RotationSpeed));
        }
        return flip();
    }

    public bool setRotation(Quaternion angle) {
        if (Time.time > rotationLock) {
            transform.rotation = angle;
        }
        return flip();
    }

    public virtual void Attack(Rigidbody2D player) {
        //-----------------------------accounts for burst-----------------------------
        if (!animations.GetCurrentAnimatorStateInfo(0).IsName("Activate")) {
            animations.Play("Reload"); //Play Animation
            StartCoroutine(AttackCommand(player));
        }
    }

    protected IEnumerator AttackCommand(Rigidbody2D player) {
        //-----------------------------Fires and playes reload animation-----------------------------
        yield return new WaitForSeconds(delay); // Pause
        if (melee) {
            rotationLock = Time.time + terminationTime;
        }
        for (int i = 0; i < numBullets; i++) { // Fire
            Quaternion sprayRot = Quaternion.Euler(0, 0, Random.Range(-bulletSpray, bulletSpray));
            GameObject tempBullet;
            if (melee) {
                tempBullet = Instantiate(bullet, transform);
                tempBullet.transform.rotation = transform.rotation * sprayRot;
            } else {
                tempBullet = Instantiate(bullet, transform.position, transform.rotation * sprayRot);
            }
            tempBullet.transform.localScale += new Vector3(bonusBulletSize, bonusBulletSize, 0);
            tempBullet.GetComponent<BulletScrpit>().damage = damage;
            if (isPlayer) {
                tempBullet.tag = "AllyDamage";
            } else {
                tempBullet.tag = "EnemyDamage";
            }
            Destroy(tempBullet, terminationTime);
            
        }

        //calculate knockback
        Vector3 tran = new Vector3(0, -knockBack, 0);
        tran = transform.rotation * tran;
        player.AddForce(tran);
    }

    public virtual void Activate(Rigidbody2D player) {
        animations.Play("Activate");
    }
}
