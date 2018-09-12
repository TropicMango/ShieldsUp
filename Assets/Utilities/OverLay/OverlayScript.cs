using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayScript : MonoBehaviour {

    // public Camera camera;
    public GameObject HealthMeter;
    public GameObject AbilityhMeter;
    private Vector3 offset;

    public IEnumerator shake() {
        transform.localPosition = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
        yield return new WaitForSeconds(0.05f);
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
