using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedestalScript : MonoBehaviour {
    public GameObject displayItem;
    public GameObject futureEvo;
    protected CharacterUpdateScript characterManager;

	void Start () {
        Instantiate(displayItem, transform);
	}

    public virtual void pickUp(PlayerScript player) {

    }

    public void setManager(CharacterUpdateScript manager) {
        characterManager = manager;
    }
}
