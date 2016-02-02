using UnityEngine;
using System.Collections;

public class GoogleGamesController : MonoBehaviour {

	void Awake () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "GoogleGamesPostScoreDizzy");
		NotificationCenter.DefaultCenter ().AddObserver (this, "GoogleGamesPostScoreFlappy");
		NotificationCenter.DefaultCenter ().AddObserver (this, "Achievements");
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoogleGamesPostScoreDizzy (Notification score) {
		Debug.Log ("Posting score Dizzy: "+score.data);
		Social.ReportScore((int) score.data, "CgkI1tTAvokMEAIQAg", (bool success) => {
			// handle success or failure
		});
	}
	
	public void GoogleGamesPostScoreFlappy (Notification score) {
		Debug.Log ("Posting score Flappy: "+score.data);
		Social.ReportScore((int) score.data, "CgkI1tTAvokMEAIQAw", (bool success) => {
		});	
	}

	public void Achievements (Notification score) {
		switch ((int) score.data) {
			case 1:
				// unlock achievement (achievement ID "CgkI1tTAvokMEAIQBA". Reaching the sky!)
				Social.ReportProgress("CgkI1tTAvokMEAIQBA", 100.0f, (bool success) => {
					// handle success or failure
				});
				break;
			case 5:
				// unlock achievement (achievement ID "CgkI1tTAvokMEAIQBQ" You're almost there!)
				Social.ReportProgress("CgkI1tTAvokMEAIQBQ", 100.0f, (bool success) => {
					// handle success or failure
				});
				break;
			case 10:
				// unlock achievement (achievement ID "CgkI1tTAvokMEAIQBQ" Bronze Medal)
				Social.ReportProgress("CgkI1tTAvokMEAIQBg", 100.0f, (bool success) => {
					// handle success or failure
				});
				break;
			case 50:
				// unlock achievement (achievement ID "CgkI1tTAvokMEAIQBw" Silver Medal)
				Social.ReportProgress("CgkI1tTAvokMEAIQBw", 100.0f, (bool success) => {
					// handle success or failure
				});
				break;
			case 100:
				// unlock achievement (achievement ID "CgkI1tTAvokMEAIQCA" Gold Medal)
				Social.ReportProgress("CgkI1tTAvokMEAIQCA", 100.0f, (bool success) => {
					// handle success or failure
				});
				break;
		}
	}
	
	public void OnLeaderBoardClick () {
		Social.ShowLeaderboardUI();
	}

	public void OnAchievementsClick () {
		Social.ShowAchievementsUI();
	}
}
