using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGivePointsJuice : TileBasicJuice {

    public void OnGivePoints() {
        // Replace this with your own juice
        this.GetComponent<SpriteRenderer>().color = Color.grey;
        SoundManager.S.tileGetPoints.Play();
    }

    // Feel free to override some base functions here if you want to
}
