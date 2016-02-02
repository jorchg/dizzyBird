using UnityEngine;
using System.Collections;

public class dizzyBirdController : MonoBehaviour {

	private float Xspeed = 2.5f; //Velocidad eje X
	//private float Yspeed = 5f; //Velocidad en el eje Y al pulsar ratón
	private float upForce = 100; //Fuerza que se va a aplicar
	private float downForce = 100; //Fuerza que se va a aplicar
	//private bool goingUp = false; //Bool para la animación hacia arriba
	private bool OutOfBounds = false;
	private bool gameOver = false;
	private bool playing = false;
	private GameObject GameOverPanel; //Objeto gameOver para el board
	private GameObject dizzyBirdObj;
	//private GameObject GetReadyTextDizzy;
	private GameObject Instructions;
	public AudioSource[] audios;

	private Animator dizzyBirdAnimator; //Objeto de tipo animator

	IEnumerator OnCollisionEnter2D(Collision2D other) { //Mensaje de colisión con obstáculo
		dizzyBirdObj.GetComponents<AudioSource> ();
		audios [1].Play ();
		Debug.Log("Collision");
		rigidbody2D.velocity = new Vector2 (0, 0);
		rigidbody2D.gravityScale = 1f;
		NotificationCenter.DefaultCenter().PostNotification (this, "StopParallax", 0);
		NotificationCenter.DefaultCenter().PostNotification (this, "StopObstaclesGen", 0);
		gameOver = true;
		NotificationCenter.DefaultCenter().PostNotification (this, "GameOver");
		yield return new WaitForSeconds(1);
		GameOverPanel.SetActive (true);
		yield return new WaitForSeconds(1);
		dizzyBirdObj.SetActive (false);
	}

	void Awake () {
		dizzyBirdAnimator = GetComponent<Animator>();

		NotificationCenter.DefaultCenter().PostNotification (this, "ResetScore", 0);

		Instructions = GameObject.Find ("instructions");
		//GetReadyTextDizzy = GameObject.Find ("GetReadyDizzy");
		GameOverPanel = GameObject.Find ("GameOverPanel"); //Board de retry level
		dizzyBirdObj = GameObject.Find ("dizzyBird");
		GameOverPanel.SetActive (false);
		
		rigidbody2D.velocity = new Vector2 (Xspeed, 0);
		rigidbody2D.gravityScale = 0f;
		rigidbody2D.drag = 0f;
	}

	// Use this for initialization
	void Start () {
	}
	
	void FixedUpdate () {
		dizzyBirdAnimator.SetFloat ("YSpeed", rigidbody2D.velocity.y);

		if (rigidbody2D.velocity.y >= 0) {
			dizzyBirdAnimator.SetBool ("upClick", false);
		}

		if (gameOver == true) {
			dizzyBirdAnimator.SetBool ("GameOver", true);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && gameOver == false) {
			Instructions.SetActive (false);
			//GetReadyTextDizzy.SetActive (false);
			audios[0].Play ();
			playing = true;
			if (rigidbody2D.velocity.y < 0) {
				rigidbody2D.gravityScale = -1f;
				dizzyBirdAnimator.SetBool ("upClick", true);
				rigidbody2D.AddForce(new Vector2 (0, upForce));
			}
		else if (rigidbody2D.velocity.y >= 0 && gameOver == false) {
				dizzyBirdAnimator.SetFloat ("YSpeed", rigidbody2D.velocity.y);
				playing = true;
				rigidbody2D.gravityScale = 1f;
				rigidbody2D.AddForce(new Vector2 (0, -downForce));
		}
		}

		if (dizzyBirdObj.transform.position.y > 5.1f && playing == true) {
			OutOfBounds = true;
		}
		
		if (OutOfBounds == true) {
			rigidbody2D.gravityScale = 1f;
		}
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.LoadLevel (0); }
	}
}
