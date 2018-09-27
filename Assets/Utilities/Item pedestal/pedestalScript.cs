using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class pedestalScript : Removable {
    public GameObject displayItem;
    public GameObject futureEvo;
    public string ItemName;
    public string BaseClass;
    public string[] EvoSet;
    protected CharacterUpdateScript characterManager;
    protected RoomGenerationScript roomGenerator;

    void Start() {
        Instantiate(displayItem, transform);
    }

    public string pickUp(PlayerScript player) {
        Debug.Log(player.characterClass + ", " + BaseClass);
        if (player.characterClass.Equals(BaseClass)) {
            string[] playerItems = player.getItems().ToArray();
            foreach (string str in playerItems) {
                Debug.Log(str);
            }
            Debug.Log("-----------------");
            bool passed = true;
            foreach (string item in EvoSet) {
                if (!playerItems.Contains(item)) { passed = false; break; }
            }
            if (passed) {
                characterManager.evoPlayer(futureEvo);
                Destroy(gameObject);
            }
        } else {
            enhance(player);
        }
        return ItemName;
    }

    public virtual void enhance(PlayerScript player) {/* override me*/ }

    public void setManager(CharacterUpdateScript manager, RoomGenerationScript RS) {
        characterManager = manager;
        roomGenerator = RS;
    }

    public IEnumerator dismantle() {
        float A = 1;
        SpriteRenderer SR = GetComponent<SpriteRenderer>();
        while (A > 0) {
            A -= 0.1f;
            SR.color = new Color(1f, 1f, 1f, A);
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }
}
