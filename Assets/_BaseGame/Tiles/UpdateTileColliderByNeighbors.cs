using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTileColliderByNeighbors : MonoBehaviour {
    // Replace box collider with edges so player doesn't get caught on box sides.

    // First, create edge colliders for each exposed side
    void Awake() {
        if (!HasNeighbor(Vector2.up)) {
            AddEdge(new Vector2(-.5f, .5f), new Vector2(.5f, .5f));
        }
        if (!HasNeighbor(Vector2.right)) {
            AddEdge(new Vector2(.5f, .5f), new Vector2(.5f, -.5f));
        }
        if (!HasNeighbor(Vector2.down)) {
            AddEdge(new Vector2(-.5f, -.5f), new Vector2(.5f, -.5f));
        }
        if (!HasNeighbor(Vector2.left)) {
            AddEdge(new Vector2(-.5f, .5f), new Vector2(-.5f, -.5f));
        }
    }

    // Then destroy the box collider. This will ensure there isn't any bumpyness.
    void Start() {
        Destroy(this.GetComponent<BoxCollider2D>());
    }

    bool HasNeighbor(Vector2 direction) {
        // Raycast in the direction
        RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position, direction, 1f, PredictiveBoxPhysics.tileLayerMask);

        // No adjacent tile in that direction (the 1 is just ourselves)
        if (hits.Length <= 1) {
            return false;
        }

        // Has an adjacent tile
        else {
            return true;
        }
    }

    void AddEdge(Vector2 a, Vector2 b) {
        List<Vector2> points = new List<Vector2>();
        points.Add(a);
        points.Add(b);

        EdgeCollider2D edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        edgeCollider.points = points.ToArray();
    }
}
