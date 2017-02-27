using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTrigger : MonoBehaviour {
    TileBasic tile;

    void Awake() {
        tile = GetComponentInParent<TileBasic>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.position.y < transform.position.y) {
            // This is kind of a hack, but we need a way to tell the player they hit there head
            Player player = other.GetComponent<Player>();
            if (player)
                player.HitHead();

            tile.BonkedOn();
        } else
            tile.SteppedOn();

    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.transform.position.y < transform.position.y)
            tile.BonkedOff();
        else
            tile.SteppedOff();
    }
}
