using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {
    public SpriteRenderer spriteRenderer;
    public float hp;
    public float movementSpeed;
    public GameObject weapon;
    protected bool stunned = false;

    public virtual void recieveDamage(float damage) { }

    // public void stun(float duration) { StartCoroutine()}

    public IEnumerator stun(float duration) {
        spriteRenderer.color = new Color(1, 0.92f, 0.016f, 1);
        stunned = true;
        yield return new WaitForSeconds(duration);
        spriteRenderer.color = new Color(1, 1, 1, 1);
        stunned = false;
    }

    public IEnumerator posion(float duration, float damagePerTick) {
        spriteRenderer.color = new Color(0.01f, 0.75f, 0, 1);
        for (int i = 0; i < duration * 5; i++) {
            yield return new WaitForSeconds(0.2f);
            recieveDamage(damagePerTick);
        }
    }

    public IEnumerator slow(float duration, float slowedPercentage) {
        spriteRenderer.color = new Color(0.33f, 0.83f, 1, 1);
        Debug.Log("slowed");
        movementSpeed *= slowedPercentage;
        yield return new WaitForSeconds(duration);
        movementSpeed /= slowedPercentage;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
