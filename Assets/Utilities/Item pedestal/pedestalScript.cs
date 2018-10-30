using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class pedestalScript : Removable {
    // public GameObject displayItem;
    public GameObject futureEvo;
    public string ItemName;
    public string BaseClass;
    public string[] EvoSet;
    public string Description;
    protected GameManagerScript gameManager;
    protected CharacterUpdateScript characterManager;
    protected RoomGenerationScript roomGenerator;

    void Start() {
        // Instantiate(displayItem, transform);
    }

    public string pickUp(PlayerScript player) {
        Debug.Log(player.characterClass + ", " + BaseClass);
        if(player.characterClass != "Base") { enhance(player); }

        gameManager.displayMessage(3f, ItemName, Description);
        
        if (player.characterClass.Equals(BaseClass)) {
            string[] playerItems = player.getItems().ToArray();
            bool passed = true;
            foreach (string item in EvoSet) {
                if (!playerItems.Contains(item)) { passed = false; break; }
            }
            if (passed) {
                characterManager.evoPlayer(futureEvo);
            }
        }
        Destroy(gameObject);
        return ItemName;
    }

    public virtual void enhance(PlayerScript player) {/* override me*/ }

    public void setManager(CharacterUpdateScript CU, RoomGenerationScript RG, GameManagerScript GM) {
        characterManager = CU;
        roomGenerator = RG;
        gameManager = GM;
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
