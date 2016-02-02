using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {
	
	private GameObject ScoreObj;
	private GameObject SecondScoreObj;
	private Vector3 SecondScorePosition;
	private int ScoreUnits;
	private int score = 0;
	private Component ScoreSprite;
	
	public Sprite[] numbers;
	public AudioSource[] audios;

	void Awake () {
		ScoreObj = GameObject.Find ("Score");
		ScoreObj.transform.localPosition = new Vector3 (0f, 4f, 5f);
		ScoreObj.GetComponent<SpriteRenderer>().sprite = numbers[0];
		NotificationCenter.DefaultCenter ().AddObserver (this, "ScoreAdd");
		NotificationCenter.DefaultCenter ().AddObserver (this, "ResetScore");
		NotificationCenter.DefaultCenter ().AddObserver (this, "GameOver");
	}

	// Use this for initialization
	void Start () {
		//score = 0;
		//ScoreObj.transform.position = new Vector2 (0f, 4.09f;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void ScoreAdd (Notification notice) {
		score++;
		audios [0].Play ();
		Debug.Log ("Score: " +score);

		if (score > 0 && score < 10) {
			ScoreObj.GetComponent<SpriteRenderer>().sprite = numbers[score];
		}
		else if (score >= 10 && score < 99) {
		ScoreObj.transform.localPosition = new Vector3 (0.42f, 4f , 5f);
		ScoreObj.GetComponent<SpriteRenderer> ().sprite = numbers[score % 10];
		//ScoreObj.transform.position = new Vector2 (0.52f, 4.09f);

		if (SecondScoreObj == null) {
			SecondScorePosition = new Vector3 (ScoreObj.transform.position.x - 0.42f, 4f, -5f);
			SecondScoreObj = (GameObject) Instantiate (ScoreObj);
			SecondScoreObj.transform.parent = ScoreObj.transform.parent;
			SecondScoreObj.transform.position = new Vector3 (ScoreObj.transform.position.x - 0.42f, 4f, 5f);
		}
		SecondScoreObj.GetComponent<SpriteRenderer> ().sprite = numbers [score / 10];
		}

		NotificationCenter.DefaultCenter ().PostNotification (this, "Achievements", score);
		}

	void GameOver (Notification noticeGameOver) {
		string sender = noticeGameOver.sender.gameObject.name;
		if (sender == "dizzyBird") {
			NotificationCenter.DefaultCenter ().PostNotification (this, "GoogleGamesPostScoreDizzy", score);
		}
		else if (sender == "dizzyBirdFlappy") {
			NotificationCenter.DefaultCenter ().PostNotification (this, "GoogleGamesPostScoreFlappy", score);
		}
	}
	
	void ResetScore (Notification noticeReset) {
		score = 0;
	}
}
