using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpdateScript : MonoBehaviour {

    public GameObject[] PlayableChar;

	// Use this for initialization
	void Start () {
        //Instantiate(PlayableChar[Random.Range(0, PlayableChar.Length)]);
        Instantiate(PlayableChar[0]);

    }
	
}
