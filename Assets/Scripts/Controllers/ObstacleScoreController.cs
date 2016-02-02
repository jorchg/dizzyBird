using UnityEngine;
using System.Collections;

public class ObstacleScoreController : MonoBehaviour {

	private GameObject ScoreCollider;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.name == "dizzyBird" || collider.gameObject.name == "dizzyBirdFlappy") {
			NotificationCenter.DefaultCenter ().PostNotification (this, "ScoreAdd");
			Destroy (ScoreCollider);
		}
	}

	void Awake () {
		ScoreCollider = GameObject.Find ("ScoreCollider");
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
