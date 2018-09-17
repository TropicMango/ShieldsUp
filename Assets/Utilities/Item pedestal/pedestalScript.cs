using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedestalScript : MonoBehaviour {
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
}
