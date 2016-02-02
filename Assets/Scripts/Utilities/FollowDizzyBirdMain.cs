using UnityEngine;
using System.Collections;

public class FollowDizzyBirdMain : MonoBehaviour {

	public Transform dizzyBird;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (dizzyBird.position.x, transform.position.y, transform.position.z);
	}
}
