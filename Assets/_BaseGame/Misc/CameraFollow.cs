using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Vector2 horizontalBounds;

	void LateUpdate () {
        if (target) {
            Vector3 currentPosition = this.transform.position;
            Vector3 targetPosition = this.transform.position;
            targetPosition.x = Mathf.Clamp(target.transform.position.x, horizontalBounds.x, horizontalBounds.y);

            this.transform.position = targetPosition;
        }
    }
}
