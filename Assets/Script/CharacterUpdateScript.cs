using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpdateScript : MonoBehaviour {

    public GameObject[] PlayableChar;
    public GameObject ui;
    public int select;

	// Use this for initialization
	void Start () {
        if (select == -1) {
            GameObject player = Instantiate(PlayableChar[Random.Range(0, PlayableChar.Length)]);
            GameObject overlay = Instantiate(ui, player.transform);
            player.GetComponent<PlayerScript>().setUI(overlay.GetComponent<OverlayScript>());
            // StartCoroutine(test(Instantiate(ui, player.transform)));
        } else {
            GameObject player = Instantiate(PlayableChar[select]);
            GameObject overlay = Instantiate(ui, player.transform);
            player.GetComponent<PlayerScript>().setUI(overlay.GetComponent<OverlayScript>());
            // player.GetComponent<PlayerScript>().setUI(ui.GetComponent<UIScript>());
        }

    }
	
}
