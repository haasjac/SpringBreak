using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnCollectable : TileBasic {
    TileSpawnCollectableJuice collectableJuice;
    public GameObject collectable;
    
    bool canSpawnCollectable = true;

    protected override void Awake() {
        base.Awake();
        collectableJuice = this.GetComponent<TileSpawnCollectableJuice>();
    }

    public override void BonkedOn() {
        base.BonkedOn();
        if (canSpawnCollectable) {
            GameObject.Instantiate(collectable, this.transform.position + Vector3.up, Quaternion.identity);
            canSpawnCollectable = false;
            collectableJuice.OnCollectableSpawned();
        }
    }
}
