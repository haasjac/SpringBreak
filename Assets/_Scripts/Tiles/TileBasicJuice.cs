using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A Basic Tile is one that can't be destroyed and doesn't spawn objects
// This includes the ground, the pipe walls, and square blocks
// While the player doesn't interact with them that much outside of collision, I've still gone ahead and exposed
// Functionality for them in case you want to do something like have them light up when something steps on it.

public class TileBasicJuice : MonoBehaviour {

    public virtual void OnSteppedOn() {
    }

    public virtual void OnSteppedOff() {
    }

    public virtual void OnBonkedOn() {
    }

    public virtual void OnBonkedOff() {
    }

}
