using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modify this as much as you want
public class EnemyJuice : MonoBehaviour, IMoveBackAndForthJuice {

    Animator anim;

    private void Start() {
        anim = GetComponentInChildren<Animator>();
    }

    public void OnKilled() {
        SoundManager.S.enemyKilled.Play();
    }

    public void OnDirectionChanged(bool nowFacingLeft) {
        anim.SetBool("facing_left", nowFacingLeft);
    }
}
