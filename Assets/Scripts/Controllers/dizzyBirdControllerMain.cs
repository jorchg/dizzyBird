using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class dizzyBirdControllerMain : MonoBehaviour {
	
	private float Xspeed = 0f;
	static private bool FirstTryToAuthenticate = false;

	void GooglePlayGamesSign () {
		Social.Active.localUser.Authenticate((bool success) => {
			// handle success or failure
		});
	}

	void Awake () {
		if (FirstTryToAuthenticate == false) {
			FirstTryToAuthenticate = true;
			PlayGamesPlatform.DebugLogEnabled = true;
			PlayGamesPlatform.Activate ();
			GooglePlayGamesSign ();
		}
		rigidbody2D.velocity = new Vector2 (Xspeed, 0);
		rigidbody2D.gravityScale = 0f;
	}

	// Use this for initialization
	void Start () {
	}
	
	void FixedUpdate () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
	}
}
