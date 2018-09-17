using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpdateScript : MonoBehaviour {

    public GameObject baseCharacter;
    public GameObject[] PlayableChar;
    public GameObject ui;
    private GameObject currentCharacter;
    public int select;

	// Use this for initialization
	void Start () {
        if(select == -5) {
            GameObject player = Instantiate(baseCharacter);
            GameObject overlay = Instantiate(ui, player.transform);
            player.GetComponent<BasePlayerScript>().setUI(overlay.GetComponent<OverlayScript>());
            currentCharacter = player;
        } else if (select == -1) {
            GameObject player = Instantiate(PlayableChar[Random.Range(0, PlayableChar.Length)]);
            GameObject overlay = Instantiate(ui, player.transform);
            player.GetComponent<PlayerScript>().setUI(overlay.GetComponent<OverlayScript>());
            currentCharacter = player;
        } else {
            GameObject player = Instantiate(PlayableChar[select]);
            GameObject overlay = Instantiate(ui, player.transform);
            player.GetComponent<PlayerScript>().setUI(overlay.GetComponent<OverlayScript>());
            currentCharacter = player;
        }

    }

    public void evoPlayer(GameObject character) {
        Vector3 playerPosition = currentCharacter.transform.position;
        Destroy(currentCharacter);
        GameObject player = Instantiate(character, playerPosition, Quaternion.Euler(0,0,0));
        GameObject overlay = Instantiate(ui, player.transform);
        player.GetComponent<PlayerScript>().setUI(overlay.GetComponent<OverlayScript>());
        currentCharacter = player;
    }
	
}
