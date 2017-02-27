using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float aggroRadius;
    EnemyJuice juice;
    
    void Start() {
        StartCoroutine(WaitForPlayerToEnterAggroRadius());
        juice = this.GetComponent<EnemyJuice>();
    }

    IEnumerator WaitForPlayerToEnterAggroRadius() {
        while (GameManager.S.player && Vector3.Distance(this.transform.position, GameManager.S.player.transform.position) > aggroRadius) {
            yield return null;
        }
        this.GetComponent<MoveBackAndForth>().enabled = true;
    }

    public void SteppedOn() {
        GameManager.S.ChangePoints(10);
        Destroy(this.gameObject);
        juice.OnKilled();
    }
}
