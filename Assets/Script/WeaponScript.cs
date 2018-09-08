using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public float RotationSpeed;
    public float terminationTime;
    public float reload;
    public GameObject bullet;
    public Animator animations;
    public int numBullets;
    public float delay;
    public float bulletSpray;
    public float knockBack;
    public float bonusBulletSize;
    public float activeAnimationTime;
    protected float coolDown;
    private bool flipRender = true;
    private bool isPlayer = false;
    public bool melee;

    public void init(bool isPlayer) {
        this.isPlayer = isPlayer;
    }

    void Update() {
        //-----------------------------determine if the weapon should be flipped-----------------------------
        if (transform.rotation.eulerAngles.z < 180) { 
            if (flipRender) {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                flipRender = false;
            }
        } else {//flips it 180 no matter what direction it's curretly in (might cause problems)
            if (!flipRender) {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                flipRender = true;
            }
        }
    }

    public void rotateLeft() {
        transform.Rotate(new Vector3(0, 0, RotationSpeed));
    }

    public void rotateRight() {
        transform.Rotate(new Vector3(0, 0, -RotationSpeed));
    }

    public void setRotation(Quaternion angle) {
        transform.rotation = angle;
    }

    public virtual void Attack(Rigidbody2D player) {
        //-----------------------------accounts for burst-----------------------------
        if (Time.time > coolDown && !animations.GetCurrentAnimatorStateInfo(0).IsName("Activate")) {
            coolDown = Time.time + reload;
            animations.Play("Reload"); //Play Animation
            StartCoroutine(AttackCommand(player));
        }
    }

    protected IEnumerator AttackCommand(Rigidbody2D player) {
        //-----------------------------Fires and playes reload animation-----------------------------
        yield return new WaitForSeconds(delay); // Pause
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
        coolDown += activeAnimationTime;
        animations.Play("Activate");
    }
}
