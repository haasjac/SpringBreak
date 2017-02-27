using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBasic : MonoBehaviour {
    TileBasicJuice juice;

    protected virtual void Awake() {
        juice = this.GetComponent<TileBasicJuice>();
    }


    public virtual void SteppedOn() {
        juice.OnSteppedOn();
    }

    public virtual void SteppedOff() {
        juice.OnSteppedOff();
    }

    public virtual void BonkedOn() {
        juice.OnBonkedOn();
    }

    public virtual void BonkedOff() {
        juice.OnBonkedOff();

    }

}
