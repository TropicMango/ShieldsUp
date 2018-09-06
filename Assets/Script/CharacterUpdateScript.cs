using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpdateScript : MonoBehaviour {

    public GameObject[] PlayableChar;
    public int select;

	// Use this for initialization
	void Start () {
        if (select == -1) {
            Instantiate(PlayableChar[Random.Range(0, PlayableChar.Length)]);
        } else {
            Instantiate(PlayableChar[select]);
        }

    }
	
}
