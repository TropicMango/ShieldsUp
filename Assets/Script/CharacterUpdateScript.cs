using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpdateScript : MonoBehaviour {

    public GameObject[] PlayableChar;
    public Camera camera;
    public int select;

	// Use this for initialization
	void Start () {
        if (select == -1) {
            GameObject player = Instantiate(PlayableChar[Random.Range(0, PlayableChar.Length)]);
            Instantiate(camera, player.transform);
        } else {
            GameObject player = Instantiate(PlayableChar[select]);
            Instantiate(camera, player.transform);
        }

    }
	
}
