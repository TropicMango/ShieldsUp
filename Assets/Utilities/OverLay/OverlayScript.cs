using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayScript : MonoBehaviour {

    // public Camera camera;
    public GameObject HealthMeter;
    public GameObject AbilityhMeter;
    private Transform follow;
    private Vector3 offset;

    public IEnumerator shake(float damage) {
        transform.localPosition = new Vector2(follow.position.x + damage * 0.02f, follow.position.y + damage * 0.02f);
        yield return new WaitForSeconds(0.025f);
        transform.localPosition = new Vector2(follow.position.x - damage * 0.02f, follow.position.y - damage * 0.02f);
        yield return new WaitForSeconds(0.025f);
        transform.localPosition = new Vector2(follow.position.x, follow.position.y);
    }

    private void Update() {
        if (follow) {
            transform.position = new Vector2(follow.position.x, follow.position.y);
        }
    }

    public void updateHP(float maxHp, float Current) {
        Debug.Log(10 * Current / maxHp);
        HealthMeter.transform.localScale = new Vector3(10 * Current / maxHp, 10, 1);
    }

    public void updateAbility(float reload, float remaining) {
        if (remaining < 0) { remaining = 0; }
        AbilityhMeter.transform.localScale = new Vector3(10 * (1 - remaining / reload), 10, 1);
    }

    public void setFollow(Transform player) {
        follow = player;
    }
}
