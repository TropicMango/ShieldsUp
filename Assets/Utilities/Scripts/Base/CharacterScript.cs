using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {
    public float hp;
    public float movementSpeed;
    public GameObject weapon;
    protected bool stunned = false;

    public virtual void recieveDamage(float damage) { }

    // public void stun(float duration) { StartCoroutine()}

    public IEnumerator stun(float duration) {
        stunned = true;
        yield return new WaitForSeconds(duration);
        stunned = false;
    }

    public IEnumerator posion(float duration, float damagePerTick) {
        for (int i = 0; i < duration * 5; i++) {
            yield return new WaitForSeconds(0.2f);
            recieveDamage(damagePerTick);
        }
    }

    public IEnumerator slow(float duration, float slowedPercentage) {
        Debug.Log("slowed");
        movementSpeed *= slowedPercentage;
        yield return new WaitForSeconds(duration);
        movementSpeed /= slowedPercentage;
    }
}
