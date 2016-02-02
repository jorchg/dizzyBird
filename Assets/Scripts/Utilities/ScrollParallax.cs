using UnityEngine;
using System.Collections;

public class ScrollParallax : MonoBehaviour {

	public float speed = 0f;

	public bool gameOver = false;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "StopParallax");
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver == false) {
			renderer.material.mainTextureOffset = new Vector2 (Time.time * speed, 0);
		}	
	}

	void StopParallax (Notification noticeStop) {
		Debug.Log ("Parallax Stop!");
		gameOver = true;
	}
}
