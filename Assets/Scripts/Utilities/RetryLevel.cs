using UnityEngine;
using System.Collections;

public class RetryLevel : MonoBehaviour {

	public void OnClick () {
		Application.LoadLevel ("GameScene");
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
