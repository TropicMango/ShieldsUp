using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummoningPortal : MonoBehaviour {

    private void Start() {
        transform.Translate(new Vector3(0, 0, -10));
    }
    public void initialize(GameObject summoned, GameObject player, GateScript GS) {
        StartCoroutine(summonSequence(summoned, player, GS));
    }


    IEnumerator summonSequence(GameObject summoned, GameObject player, GateScript GS) {
        yield return new WaitForSeconds(2);
        Instantiate(summoned, transform.position, Quaternion.Euler(0,0,0)).GetComponent<EnemyScript>().initialize(player, GS);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
