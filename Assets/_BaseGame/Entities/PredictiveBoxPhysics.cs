using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tile based platformers suck unless you adjust the physics a bit.
// For this game, instead of using Unity's collision-response physics
// I just boxcast in the direction to predict when an object will collide
// with another object.
public class PredictiveBoxPhysics : MonoBehaviour {

    public static int tileLayer = 8;
    public static int tileLayerMask = 1 << tileLayer;
    static float thresholdOffset = .005f;

    BoxCollider2D boxCollider;

    [HideInInspector] public Vector3 velocity;
    [HideInInspector] public bool grounded = false;
    [HideInInspector] public bool wasGrounded = false;

    void Start() {
        boxCollider = this.GetComponent<BoxCollider2D>();
    }

    // Physics are being done 
    void Update () {
        wasGrounded = grounded;
        grounded = false;

        // Rather than just do one box cast, do it on each axix separetely.
        float xDist = Mathf.Abs(velocity.x * Time.deltaTime);
        RaycastHit2D xHit = Physics2D.BoxCast(this.transform.position, boxCollider.size, 0f, Mathf.Sign(velocity.x) * Vector3.right, xDist, tileLayerMask);
        if (!xHit) {
            this.transform.position += Vector3.right * Mathf.Sign(velocity.x) * xDist;
        } else {
            this.transform.position += Vector3.right * Mathf.Sign(velocity.x) * (xHit.distance - thresholdOffset);
            velocity.x = 0;
        }
        
        float yDist = Mathf.Abs(velocity.y * Time.deltaTime);
        RaycastHit2D yHit = Physics2D.BoxCast(this.transform.position, boxCollider.size, 0f, Mathf.Sign(velocity.y) * Vector3.up, yDist, tileLayerMask);
        if (!yHit) {
            this.transform.position += Vector3.up * Mathf.Sign(velocity.y) * yDist;
        } else {
            this.transform.position += Vector3.up * Mathf.Sign(velocity.y) * (yHit.distance - thresholdOffset);
            if (velocity.y < 0)
                grounded = true;
            velocity.y = 0;
        }

	}
}
