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
        StartCoroutine(eveolutionAnimation(player));
    }

    private IEnumerator eveolutionAnimation(GameObject futurePlayer) {
        futurePlayer.SetActive(false);
        bool playerDir = currentCharacter.GetComponent<PlayerScript>().getFacingLeft();
        futurePlayer.GetComponent<PlayerScript>().updatePlayerSprite(playerDir);
        currentCharacter.GetComponent<PlayerScript>().enabled = false;
        WeaponScript WS = currentCharacter.GetComponent<PlayerScript>().GetWeaponScript();
        if (WS) { WS.enabled = false; }
        futurePlayer.GetComponent<PlayerScript>().enabled = false;

        for (int i = 30; i > 0; i--) {
            if (i > 25) { yield return new WaitForSeconds(0.2f); }
            else if (i > 15) { yield return new WaitForSeconds(0.1f); }
            else { yield return new WaitForSeconds(0.05f); }

            if (i % 2 == 0) {
                futurePlayer.SetActive(false);
                currentCharacter.SetActive(true);
            } else {
                futurePlayer.SetActive(true);
                currentCharacter.SetActive(false);
            }
        }

        futurePlayer.GetComponent<PlayerScript>().enabled = true;
        futurePlayer.GetComponent<PlayerScript>().setStats(currentCharacter.GetComponent<PlayerScript>().getStats());
        Destroy(currentCharacter);
        
        setUpPlayer(futurePlayer);
        //Time.timeScale = 1;
    }

    private void setUpPlayer(GameObject player) {
        Debug.Log(player);
        player.GetComponent<PlayerScript>().setUI(ui);
        currentCharacter = player;
        ui.setFollow(player.transform);
        // currentCharacter.GetComponent<PlayerScript>().GetWeaponScript().transform.rotation = (Quaternion.Euler(0, 0, 270)); //playerDir ? Quaternion.Euler(0, 0, 90) : Quaternion.Euler(0, 0, 270)
    }
	
}
