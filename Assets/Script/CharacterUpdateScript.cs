using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpdateScript : MonoBehaviour {

    public GameObject[] PlayableChar;

	// Use this for initialization
	void Start () {
        Instantiate(PlayableChar[0]);
	}
	
}
