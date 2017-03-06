using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modify this as much as you want
public class PlayerJuice : MonoBehaviour {
    Player player;
    Animator anim;
    bool facing_right;
    bool idle;
    bool grounded;
    Vector3 velocity;

    void Awake() {
        player = this.GetComponent<Player>();
        anim = GetComponentInChildren<Animator>();
    }

	// Use this for initialization
	void Start () {
        facing_right = true;
        velocity = Vector3.zero;
        grounded = true;
    }
	
	// Update is called once per frame, use this for anything you need to persistently update
    // For example, if your animation depends on the player speed set that here.
	void Update () {
        // Here are some variables you may want to use
        velocity = player.GetVelocity();
        grounded = player.GetIsGrounded();

        idle = (velocity.magnitude <= 1f && grounded);
        if (Input.GetAxis("Horizontal") < 0)
            facing_right = false;
        if (Input.GetAxis("Horizontal") > 0)
            facing_right = true;

        anim.SetBool("facing_right", facing_right);
        anim.SetBool("idle", idle); 
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
