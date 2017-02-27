using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modify this as much as you want
public class PlayerJuice : MonoBehaviour {
    Player player;

    void Awake() {
        player = this.GetComponent<Player>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame, use this for anything you need to persistently update
    // For example, if your animation depends on the player speed set that here.
	void Update () {
        // Here are some variables you may want to use
        Vector3 velocity = player.GetVelocity();
        bool grounded = player.GetIsGrounded();
    }

    // All of the functions below are called by other scripts

    public void OnJump() {
        SoundManager.S.playerJump.Play();
    }

    public void OnJumpOffEnemy() {
        OnJump(); //Just use OnJump's juice unless you want to do something special off of an enemy
        // But consider doing that in either GameManagerJuice or EnemyJuice
    }

    // When the player hits any tile with their head
    public void OnHitHead() {
        SoundManager.S.playerHitHead.Play();
    }

    public void OnLanded() {
        SoundManager.S.playerLanded.Play();
    }

    public void OnCollectedPowerup() {
        // Only mess with this if you are changing the player when you grab a powerup
        // Otherwise do it in GameManagerJuice or CollectableJuice
    }

    public void OnDied(bool sourceIsEnemy) {
        if (sourceIsEnemy) { //Ran into enemy

        } else { //Fell in death zone

        }
        SoundManager.S.playerDied.Play();
    }

    public void OnCompletedLevel() {

    }
}
