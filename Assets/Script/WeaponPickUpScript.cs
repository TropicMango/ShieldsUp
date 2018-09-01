using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUpScript : MonoBehaviour {

    public GameObject weapItem; //unchanged weapon that is passed on
    private GameObject displayItem; //changed weapon that is unable to fire

    // Use this for initialization
    void Start () {
        setUpDisplay(weapItem);
    }

    // Update is called once per frame
    void Update() {
        transform.Rotate(new Vector3(0, 0, 1));
    }

    public GameObject getItem(GameObject replacementWeap) {
        //-------------------------- fix me plz T^T -------------------------------
        /*GameObject tempWeap = weapItem;
        weapItem = replacementWeap;
        Destroy(displayItem);
        setUpDisplay(weapItem);
        Debug.Log("replacement weap: " + weapItem);
        Debug.Log("temp weap: "+tempWeap);
        return tempWeap;*/
        return weapItem;
    }

    void setUpDisplay (GameObject newWeap) {
        displayItem = Instantiate(newWeap.gameObject, transform);
        Destroy(displayItem.GetComponent<WeaponScript>());
        displayItem.transform.localPosition = new Vector3(0, -0.2f, 0);
        displayItem.transform.localScale = new Vector3(10, 10, 0);
    }

}
