using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummoningPortal : MonoBehaviour {
    private GameObject summoned;

    private void Start() {
        
    }

    public void setEnemy(GameObject enemy) {
        summoned = enemy;
    }
}
