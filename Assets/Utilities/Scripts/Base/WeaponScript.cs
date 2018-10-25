using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public GameObject bullet;
    public Animator animations;
    protected float reloadCoolDown;
    protected float abilityCoolDown;
    protected float rotationLock; //lock rotation when casting
    protected GameObject player; //do stuff
    protected GateScript currentRoom; //collect all the enemies in the room
    private bool isPlayer = false; //determine ally or enemy damage
    private float baseReload; //calculate for the animation speed
    public float RotationSpeed;
    public float bulletSpray;
    public float bulletSize;
    public float recoil;
    public float damage;
    public float pierce;
    public float bulletSpeed;
    public float reload;
    public float abilityRecharge;
    public float activationTime;
    public float delay;
    public float terminationTime;
    public bool melee;
    public AddonEffectScript[] Effects;
    public AddonOnhitScript[] Onhit;

    public void init(GameObject player, bool isPlayer) {
        this.isPlayer = isPlayer;
        this.player = player;
        baseReload = reload;
    }

    public void setReload(float newReloadSpeed) {
        reload = newReloadSpeed;
        animations.speed = baseReload / newReloadSpeed;
    }

    public bool flip() {
        if (transform.rotation.eulerAngles.z < 180) {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            return false;
        } else {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            return true;
        }

    }

    public virtual bool rotateAngle(float targetAngle) {
        if (Time.time > rotationLock) {
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
        }
        return flip();
    }

    public bool setRotation(Quaternion angle) {
        if (Time.time > rotationLock) {
            transform.rotation = angle;
        }
        return flip();
    }

    public virtual void checkAttack() {
        if (Time.time > reloadCoolDown) {
            reloadCoolDown = Time.time + reload;
            this.Attack(); // tranform is passed for knock back
        }
    }

    protected virtual void Attack() {
        //-----------------------------accounts for burst-----------------------------
        animations.Play("Reload"); //Play Animation
        StartCoroutine(AttackCommand());
    }

    protected virtual IEnumerator AttackCommand(float offSet = 0.12345f) {
        //-----------------------------Fires and playes reload animation-----------------------------
        yield return new WaitForSeconds(delay); // Pause
        if (melee) {
            rotationLock = Time.time + terminationTime;
        }
        

        fireBullet(offSet);

        //calculate knockback
        if (player) {
            Vector3 tran = new Vector3(0, -recoil, 0);
            tran = transform.rotation * tran;
            player.GetComponent<Rigidbody2D>().AddForce(tran);
        }

        followUp();
    }

    protected virtual void fireBullet(float offSet) {
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

        tempBullet.GetComponent<BulletScrpit>().setStats(damage, bulletSpeed, pierce, bulletSize);

        if (isPlayer) {
            tempBullet.tag = "AllyDamage";
        } else {
            tempBullet.tag = "EnemyDamage";
        }
        Destroy(tempBullet, terminationTime);
    }

    protected virtual void followUp() { }

    public virtual void checkActivation() {
        if (Time.time > abilityCoolDown) {
            this.Activate();
            abilityCoolDown = Time.time + abilityRecharge;
            reloadCoolDown += activationTime;
        }
    }

    protected virtual void Activate() {
        animations.Play("Activate");
    }

    public virtual float getAbilityCoolDown() {
        return abilityCoolDown - Time.time;
    }

    public bool activatable() {
        if (Time.time > abilityCoolDown) {
            abilityCoolDown = Time.time + abilityRecharge;
            return true;
        } else {
            return false;
        }
    }

    public void setRoom(GateScript room) {
        currentRoom = room;
    }

    public virtual void activateStatsModifier() { }

    public PlayerStats GetWeapStats(float movementSpeed) {
        PlayerStats PS = new PlayerStats();
        PS.setStats(movementSpeed, RotationSpeed, bulletSpray, recoil, bulletSize, damage, pierce, bulletSpeed, reload, abilityRecharge, Effects, Onhit);
        return PS;
    }
}
