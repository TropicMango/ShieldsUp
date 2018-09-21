using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdEye : WeaponScript {
    private GameObject target;
    private GameObject watcher;
    private LineRenderer lr;
    private float range = 7;

    private void Start() {
        watcher = Instantiate(bullet, transform);
        lr = GetComponent<LineRenderer>();
    }

    override
    protected IEnumerator AttackCommand(Rigidbody2D player, float offSet = 0.12345f) {
        Debug.Log("damaging");
        yield return new WaitForSeconds(delay);
        if (watcher.active) {
            target.GetComponent<EnemyScript>().recieveDamage(damage);
            float angle = -Vector2.SignedAngle(transform.position - watcher.transform.position, Vector2.up);
            target.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,angle)* new Vector2(0,-300));
        }
    }

    private void Update() {
        GameObject[] EneList = GameObject.FindGameObjectsWithTag("Enemy");
        if (EneList.Length > 0) {
            lr.enabled = true;
            watcher.SetActive(true);
            foreach ( GameObject EN in EneList){
                if (target && target.tag == "Enemy") {
                    if(Vector2.Distance(target.transform.position, transform.position) > Vector2.Distance(EN.transform.position, transform.position)) {
                        target = EN;
                    }
                } else {
                    target = EN;
                }
            }
            if (Vector2.Distance(target.transform.position, transform.position) < range) {
                watcher.transform.position = target.transform.position + new Vector3(0,1,0);
                lr.SetPosition(0, watcher.transform.position);
                lr.SetPosition(1, transform.position);
            } else {
                lr.enabled = false;
                watcher.SetActive(false);
            }
        } else {
            lr.enabled = false;
            watcher.SetActive(false);
        }
    }
}