using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGivePoints : TileBasic {
    TileGivePointsJuice pointsJuice;
    bool canGivePoints = true;

    protected override void Awake() {
        base.Awake();
        pointsJuice = this.GetComponent<TileGivePointsJuice>();
    }

    public override void BonkedOn() {
        base.BonkedOn();
        if (canGivePoints) {
            GameManager.S.ChangePoints(5);
            canGivePoints = false;
            pointsJuice.OnGivePoints();
        }
    }

}
