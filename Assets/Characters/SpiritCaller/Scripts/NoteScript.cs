using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : BulletScrpit {
    public Sprite[] notes;
    public Sprite soulSprite;
    private bool soul = false;
    private GameObject returnTarget;

    public void setReturn(GameObject player) {
        this.returnTarget = player;
    }

    private void Start() {
        transform.Translate(new Vector2(0, offSetDist));
        if(transform.rotation.eulerAngles.z > 180) {
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<SpriteRenderer>().flipY = true;
        }
        GetComponent<SpriteRenderer>().sprite = notes[Random.Range(0, notes.Length - 1)];
    }

    void FixedUpdate() {
        //moving the bullet
        if (!soul) {
            transform.Translate(new Vector2(0, movementSpeed));
        } else {
            if(Vector2.Distance(transform.position, returnTarget.transform.position) < movementSpeed) {
                returnTarget.GetComponent<WhistleScript>().charge();
                Destroy(gameObject);
            }
            float angle = -Vector2.SignedAngle(transform.position - returnTarget.transform.position, Vector2.up);
            transform.Translate(Quaternion.Euler(0, 0, angle) * new Vector2(0, -movementSpeed/2));
            movementSpeed *= 1.01f;
        }
    }

    override
    public float Hit(GameObject gm) {
        GetComponent<SpriteRenderer>().sprite = soulSprite;
        soul = true;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        return damage;
    }
}
