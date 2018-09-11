using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionTokenScript : MonoBehaviour {
    private RoomGenerationScript RG;
    private float rotationSpeed;
    private float spinTill;
    private bool passed = false;

    void Update() {
        if (passed && Time.time < spinTill) {
            transform.Rotate(new Vector3(0, 0, rotationSpeed));
            rotationSpeed += 0.1f;
        }
    }

    public void setGeneratorScript(RoomGenerationScript RG) {
        this.RG = RG;
    }

    public void progress(GameObject player) {
        if (!passed) {
            passed = true;
            spinTill = Time.time + 3;
            StartCoroutine(reset(player));
        }
    }

    IEnumerator reset(GameObject player) {
        yield return new WaitForSeconds(3f);
        player.transform.position = new Vector3(0, 0, 0);
        RG.progression();
        
    }
}
