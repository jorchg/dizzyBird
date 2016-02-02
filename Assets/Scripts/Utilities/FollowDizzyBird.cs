using UnityEngine;
using System.Collections;

public class FollowDizzyBird : MonoBehaviour {

	public Transform dizzyBird;
	private float NewPosition;
	private float LastPosition;

	void Awake () {
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (dizzyBird.position.x + 1, transform.position.y, transform.position.z);
	}
}
