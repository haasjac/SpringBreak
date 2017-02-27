using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveBackAndForthJuice {
    void OnDirectionChanged(bool nowFacingLeft);
}

public class MoveBackAndForth : MonoBehaviour {
    public float speed;
    public float gravity;
    public bool facingLeft = true;

    PredictiveBoxPhysics physics;
    IMoveBackAndForthJuice moveBackAndForthJuice;

    void Awake() {
        physics = this.GetComponent<PredictiveBoxPhysics>();
        moveBackAndForthJuice = this.GetComponent<IMoveBackAndForthJuice>();
    }

    void Start() {
        physics.velocity.x = facingLeft ? -speed : speed;
    }
	
	// Update is called once per frame
	void Update () {
        // Hit a wall, turn around
        if (physics.velocity.x == 0) {
            facingLeft = !facingLeft;
            physics.velocity.x = facingLeft ? -speed : speed;
            moveBackAndForthJuice.OnDirectionChanged(facingLeft);
        }
        physics.velocity.y -= gravity * Time.deltaTime;
    }
}
