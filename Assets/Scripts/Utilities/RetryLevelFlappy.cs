using UnityEngine;
using System.Collections;

public class RetryLevelFlappy : MonoBehaviour {

	public void OnClick () {
		Application.LoadLevel ("GameSceneFlappy");
	}

	public void OnNoClick () {
		Application.LoadLevel ("MainScene");
	}

	// Use this for initialization
	void Start () {
	
	}

	void Update () {

	}
}
