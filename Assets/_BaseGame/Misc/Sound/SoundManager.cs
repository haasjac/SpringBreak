using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This one of the few classes without the Juice suffix that you're 
// encouraged to modify (or even delete if you don't like it)
public class SoundManager : MonoBehaviour {
    public static SoundManager S;

    public AudioSource playerJump;
    public AudioSource playerHitHead;
    public AudioSource playerLanded;
    public AudioSource playerDied;

    public AudioSource timerTick;

    public AudioSource enemyKilled;

    public AudioSource collectableGrabbed;

    public AudioSource tileBroken;
    public AudioSource tileGetPoints;
    public AudioSource tileCollectableSpawned;

    public AudioSource levelComplete;


    void Awake() {
        S = this;
    }
}
