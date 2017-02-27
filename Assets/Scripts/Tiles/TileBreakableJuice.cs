using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBreakableJuice : TileBasicJuice {

    public override void OnBonkedOn() {
        base.OnBonkedOn();
        SoundManager.S.tileBroken.Play();
    }
    
    // Feel free to override some base functions here if you want to
}
