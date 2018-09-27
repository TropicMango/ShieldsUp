using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhistleScript : WeaponScript {
    public GameObject ReleasedSpirit;

    override
    protected void fireBullet(float offSet) {
        offSet = Random.Range(-bulletSpray, bulletSpray);
        GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, offSet));

        tempBullet.GetComponent<BulletScrpit>().setStats(damage, bulletSpeed, pierce, bonusBulletSize);
        tempBullet.GetComponent<NoteScript>().setReturn(gameObject);
        Destroy(tempBullet, terminationTime);
    }

    public void charge() {
        abilityCoolDown += 0.5f;
    }

    override
    public float getAbilityCoolDown() {
        return abilityRecharge-abilityCoolDown;
    }

    override
    public void checkActivation() {
        if (abilityCoolDown > abilityRecharge) {
            this.Activate();
            abilityCoolDown = 0;
            coolDown += activationTime;
        }
    }

    override
    protected void Activate() {
        base.Activate();
        GameObject spirit = Instantiate(ReleasedSpirit, transform.position, Quaternion.Euler(0, 0, 0));
        spirit.GetComponent<RelasedScript>().setGate(currentRoom);
        Destroy(spirit, 20);
    }


}
