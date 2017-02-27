using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBreakable : TileBasic {
    public override void BonkedOn() {
        base.BonkedOn();
        Destroy(this.gameObject);
    }

}
