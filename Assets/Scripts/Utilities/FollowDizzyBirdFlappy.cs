using UnityEngine;
using System.Collections;

public class FollowDizzyBirdFlappy : MonoBehaviour {

	public Transform dizzyBirdFlappy;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (dizzyBirdFlappy.position.x + 1, transform.position.y, transform.position.z);
	}
}
