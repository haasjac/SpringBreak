using UnityEngine;
using System.Collections;

enum AllowJumpState {
    grounded,
    recentlyGrounded,
    airborne
}

public class Player : MonoBehaviour {
    PlayerJuice juice;
    PredictiveBoxPhysics physics;

    // Horizontal
    public float maxHorizontalSpeed = 5f;
    [Header("This isn't juice, don't touch this graph")]
    public AnimationCurve accelerationByCurrentSpeed;
    public float initialJumpVelocity = 12.12f;
    public float shortHopReduction = 8f;

    // Vertical
    public float gravity = 16.3f * 2f;

    // These are used to make jumping feel more responsive
    bool jumpInput = false;
    bool canJump = true;

    void Awake() {
        physics = this.GetComponent<PredictiveBoxPhysics>();
        juice = this.GetComponent<PlayerJuice>();
    }

    // Update is called once per frame
    void Update() {

        // Change Velocity
        float inputDirection = Input.GetAxisRaw("Horizontal");
        if (GameManager.S.gameEnding) // Run off the right side of the screen on win
            inputDirection = 1;
        float targetDirection = Utility.SignWithZero(inputDirection - physics.velocity.x / maxHorizontalSpeed);
        float acceleration = accelerationByCurrentSpeed.Evaluate(Mathf.Abs(targetDirection - physics.velocity.x / maxHorizontalSpeed));
        physics.velocity.x += targetDirection * acceleration * Time.deltaTime;
        physics.velocity.x = Mathf.Sign(physics.velocity.x) * Mathf.Min(Mathf.Abs(physics.velocity.x), maxHorizontalSpeed);
        if (inputDirection == 0 && Mathf.Sign(physics.velocity.x) == targetDirection) {
            physics.velocity.x = 0;
        }

        physics.velocity.y -= gravity * Time.deltaTime;
        physics.velocity.y = Mathf.Max(-initialJumpVelocity, physics.velocity.y);

        // Handle Jumping
        if (Input.GetButtonDown("Jump")) // Input buffer
            StartCoroutine(JumpInputBuffer());
        if (physics.grounded)
            canJump = true;
        if (physics.grounded && !physics.wasGrounded)
            juice.OnLanded();
        else if (!physics.grounded && physics.wasGrounded && physics.velocity.y < 0)
            StartCoroutine(LeftGroundBuffer());
        if (canJump && jumpInput && !GameManager.S.gameEnding) {
            juice.OnJump();
            Jump();
        }
    }

    // This is included so if you press jump slightly before you hit the ground, you'll still jump
    IEnumerator JumpInputBuffer() {
        jumpInput = true;
        for (float f = 0; f < .15f; f += Time.deltaTime) {
            yield return null;
        }
        jumpInput = false;
    }

    void Jump() {
        jumpInput = false;
        physics.velocity.y = initialJumpVelocity;
        canJump = false;
        physics.grounded = false;
        StartCoroutine(CheckShortHop());
    }

    // This is included so if you walk off a tile you have a split second to press jump and still jump 
    IEnumerator LeftGroundBuffer() {
        for (float f = 0; f < .15f; f += Time.deltaTime) {
            if (physics.grounded || physics.velocity.y > 0)
                yield break;
            yield return null;
        }
        canJump = false;
    }

    IEnumerator CheckShortHop() {
        while(Input.GetButton("Jump")) {
            if (physics.grounded == true || physics.velocity.y < 0)
                yield break;
            yield return null;
        }

        float applyTime = .1f;
        for (float f = 0; f < applyTime; f += Time.deltaTime) {
            physics.velocity.y -= shortHopReduction * Time.deltaTime / applyTime;
            if (physics.grounded == true)
                yield break;
            yield return null;
        }
    }    

    public void HitHead() {
        physics.velocity.y = 0;
        juice.OnHitHead();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            if (transform.position.y - other.transform.position.y > .2f) {
                juice.OnJumpOffEnemy();
                Jump();
                other.GetComponent<Enemy>().SteppedOn();
            }
            else {
                Die(true);
            }
        }
        else if (other.tag == "Collectable") {
            other.GetComponent<Collectable>().Collect();
        }
        else if (other.tag == "DeathZone") {
            Die(false);
        }
        else if (other.tag == "WinZone") {
            GameManager.S.LevelComplete();
            juice.OnCompletedLevel();
        }
    }

    void Die(bool fromEnemy) {
        juice.OnDied(fromEnemy);
        Destroy(this.gameObject);
        GameManager.S.PlayerDied();
    }

    public Vector2 GetVelocity() {
        return physics.velocity;
    }

    public bool GetIsGrounded() {
        return physics.grounded;
    }
}
