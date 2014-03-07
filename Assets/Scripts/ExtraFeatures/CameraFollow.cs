using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public bool oneDirectionOnly;

	void Update () {
		float delta = target.position.x - transform.position.x;
		float bravo = target.position.y - transform.position.y;
		if (!oneDirectionOnly || delta > 0.0f) {
			transform.Translate(delta * Time.deltaTime, bravo * Time.deltaTime, 0.0f);
		}
	}
}
