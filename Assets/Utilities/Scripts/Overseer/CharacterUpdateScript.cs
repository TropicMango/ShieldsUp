using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpdateScript : MonoBehaviour {

    public GameObject[] PlayableChar;
    public OverlayScript ui;
    private GameObject currentCharacter;
    public int select;

	// Use this for initialization
	void Start () {
        GameObject player;
        if (select == -5) {
            player = Instantiate(PlayableChar[0]);
            for (int i=1; i<PlayableChar.Length; i++) {
                player = Instantiate(PlayableChar[i]);
            }
        } else if (select == -1) {
            player = Instantiate(PlayableChar[Random.Range(0, PlayableChar.Length)]);
        } else {
            player = Instantiate(PlayableChar[select]);
        }
        setUpPlayer(player);
    }

    public void evoPlayer(GameObject character) {
        currentCharacter.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        Vector3 playerPosition = currentCharacter.transform.position;
        GameObject player = Instantiate(character, playerPosition, Quaternion.Euler(0,0,0));
        StartCoroutine(eveolutionAnimation(currentCharacter, player));
    }

    private IEnumerator eveolutionAnimation(GameObject currentPlayer, GameObject futurePlayer) {
        futurePlayer.SetActive(false);
        currentCharacter.GetComponent<PlayerScript>().enabled = false;
        futurePlayer.GetComponent<PlayerScript>().enabled = false;

        for (int i = 30; i > 0; i--) {
            if (i > 25) { yield return new WaitForSeconds(0.2f); }
            else if (i > 15) { yield return new WaitForSeconds(0.1f); }
            else { yield return new WaitForSeconds(0.05f); }

            if (i % 2 == 0) {
                futurePlayer.SetActive(false);
                currentPlayer.SetActive(true);
            } else {
                futurePlayer.SetActive(true);
                currentPlayer.SetActive(false);
            }
        }

        futurePlayer.GetComponent<PlayerScript>().enabled = true;
        Destroy(currentCharacter);
        setUpPlayer(futurePlayer);
        //Time.timeScale = 1;
    }

    private void setUpPlayer(GameObject player) {
        Debug.Log(player);
        player.GetComponent<PlayerScript>().setUI(ui);
        currentCharacter = player;
        ui.setFollow(player.transform);
    }
	
}
