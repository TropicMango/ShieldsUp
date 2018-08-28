using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovementScript : MonoBehaviour {

    public float RotationSpeed;
    public float reload;
    public GameObject bullet;
    public Animator animations;
    private float coolDown;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(new Vector3(0, 0, RotationSpeed));
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(new Vector3(0, 0, -RotationSpeed));
            
        }
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space) && Time.time > coolDown) {
            animations.Play("ReloadAnimation");
            Instantiate(bullet, transform.position, transform.rotation);
            coolDown = Time.time + reload;
        }
    }
}
