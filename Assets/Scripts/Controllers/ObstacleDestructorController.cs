using UnityEngine;
using System.Collections;

public class ObstacleDestructorController : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log("Obstacle Destruction");
		DestroyObject (other.gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
