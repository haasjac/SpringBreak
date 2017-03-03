using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnCollectableJuice  : TileBasicJuice {

    public void OnCollectableSpawned() {
        // Replace this with your own juice
        this.GetComponent<SpriteRenderer>().color = Color.grey;
        SoundManager.S.tileCollectableSpawned.Play();
    }


    // Feel free to override some base functions here if you want to

}