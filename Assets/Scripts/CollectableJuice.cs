using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modify this as much as you want
public class CollectableJuice : MonoBehaviour, IMoveBackAndForthJuice {

    public void OnGrabbed() {
        SoundManager.S.collectableGrabbed.Play();
    }

    public void OnDirectionChanged(bool nowFacingLeft) {

    }
}

