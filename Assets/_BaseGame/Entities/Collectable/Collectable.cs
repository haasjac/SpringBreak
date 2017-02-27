using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public void Collect() {
        GameManager.S.ChangePoints(25);
        this.GetComponent<CollectableJuice>().OnGrabbed();
        Destroy(this.gameObject);
    }

}
