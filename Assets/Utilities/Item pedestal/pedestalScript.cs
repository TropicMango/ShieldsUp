using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedestalScript : Removable {
    public GameObject displayItem;
    public GameObject futureEvo;
    protected CharacterUpdateScript characterManager;
    protected RoomGenerationScript roomGenerator;

	void Start () {
        Instantiate(displayItem, transform);
	}

    public virtual void pickUp(PlayerScript player) {
        roomGenerator.progression();
    }

    public void setManager(CharacterUpdateScript manager, RoomGenerationScript RS) {
        characterManager = manager;
        roomGenerator = RS;
    }

    public IEnumerator dismantle() {
        float A = 1;
        SpriteRenderer SR = GetComponent<SpriteRenderer>();
        while (A > 0) {
            A -= 0.1f;
            SR.color = new Color(1f, 1f, 1f, A);
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }
}
