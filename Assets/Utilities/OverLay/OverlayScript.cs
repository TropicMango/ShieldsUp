using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayScript : MonoBehaviour {

    // public Camera camera;
    public GameObject HealthMeter;
    public GameObject AbilityhMeter;
    private Vector3 offset;

    public IEnumerator shake(float damage) {
        transform.localPosition = new Vector2(damage*0.02f, damage * 0.02f);
        yield return new WaitForSeconds(0.025f);
        transform.localPosition = new Vector2(-damage * 0.02f, -damage * 0.02f);
        yield return new WaitForSeconds(0.025f);
        transform.localPosition = new Vector2(0, 0);

    }

    public void updateHP(float maxHp, float Current) {
        HealthMeter.transform.localScale = new Vector3(0.43f * Current / maxHp, 0.43f, 1);
    }

    public void updateAbility(float reload, float remaining) {
        if (remaining < 0) { remaining = 0; }
        AbilityhMeter.transform.localScale = new Vector3(0.43f * (1-remaining/reload), 0.43f, 1);
    }
}
