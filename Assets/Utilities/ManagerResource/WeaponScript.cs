using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public float RotationSpeed;
    public float terminationTime;
    public GameObject bullet;
    public Animator animations;
    public float delay;
    public float bulletSpray;
    public float knockBack;
    public float bonusBulletSize;
    public float damage;
    public float explosionSize;
    public float pierce;
    public float bulletSpeed;
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

    public bool rotateAngle(float targetAngle) {
        if (transform.rotation.eulerAngles.z > targetAngle - RotationSpeed && transform.rotation.eulerAngles.z < targetAngle + RotationSpeed) {
            transform.rotation = Quaternion.Euler(0, 0, targetAngle);
        } else if (targetAngle + 180 <= 360) {
            if (transform.rotation.eulerAngles.z > targetAngle + 180 || transform.rotation.eulerAngles.z < targetAngle) {
                transform.Rotate(new Vector3(0, 0, RotationSpeed));
            } else {
                transform.Rotate(new Vector3(0, 0, -RotationSpeed));
            }
        } else { // compensating for the jump from 360 to 0
            if (transform.rotation.eulerAngles.z > targetAngle - 180 && transform.rotation.eulerAngles.z < targetAngle) {
                transform.Rotate(new Vector3(0, 0, RotationSpeed));
            } else {
                transform.Rotate(new Vector3(0, 0, -RotationSpeed));
            }
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

    protected virtual IEnumerator AttackCommand(Rigidbody2D player, float offSet = 0.12345f) {
        //-----------------------------Fires and playes reload animation-----------------------------
        yield return new WaitForSeconds(delay); // Pause
        if (melee) {
            rotationLock = Time.time + terminationTime;
        }
        // Fire
        GameObject tempBullet;
        if (offSet == 0.12345f) {
            offSet = Random.Range(-bulletSpray, bulletSpray); // if offset not stated do random spray
        }
        Quaternion sprayRot = Quaternion.Euler(0, 0, offSet);

        if (melee) {
            tempBullet = Instantiate(bullet, transform);
            tempBullet.transform.rotation = transform.rotation * sprayRot;
        } else {
            tempBullet = Instantiate(bullet, transform.position, transform.rotation * sprayRot);
        }
        tempBullet.transform.localScale += new Vector3(bonusBulletSize, bonusBulletSize, 0);
        tempBullet.GetComponent<BulletScrpit>().setStats(damage, bulletSpeed, explosionSize, pierce);

        if (isPlayer) {
            tempBullet.tag = "AllyDamage";
        } else {
            tempBullet.tag = "EnemyDamage";
        }
        Destroy(tempBullet, terminationTime);

        //calculate knockback
        if (player) {
            Vector3 tran = new Vector3(0, -knockBack, 0);
            tran = transform.rotation * tran;
            player.AddForce(tran);
        }
    }

    public virtual void Activate(Rigidbody2D player) {
        animations.Play("Activate");
    }
}
