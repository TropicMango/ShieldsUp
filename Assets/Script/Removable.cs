using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Removable : MonoBehaviour {
    public virtual void remove() {
        Destroy(gameObject);
    }
}
