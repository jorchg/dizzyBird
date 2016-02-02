using UnityEngine;
using System.Collections;

public class ObstaclesGenController : MonoBehaviour {

	public GameObject[] obj; //Objeto obstáculo

	private float minTime = 2f; //Tiempo mínimo entre generación
	private float maxTime = 3f; //Tiempo máximo entre generación
	private float minRange = -2.37f; //Rango minimo en el eje Y de generación del obstáculo
	private float maxRange = 4.14f; //Rango máximo en el eje Y de generación del obstáculo
	private bool firstGenerated = true; //Bool para saber si es la primera generación
	private bool gameOver = false;

	void StopObstaclesGen (Notification stopNotice) {
		gameOver = true;	
	}

	void Generate () {
		firstGenerated = false;
		transform.position = new Vector3 (transform.position.x, Random.Range (minRange, maxRange), 0);
			//Nueva posición aleatoria en el eje Y del obstáculo
		if (gameOver == false) {
			Instantiate (obj [0], transform.position, Quaternion.identity);
			//Nueva instancia del nuevo obstáculo
		}
		Debug.Log ("Obstacle Creation");
		Invoke ("Generate", Random.Range (minTime, maxTime));
			//Invoco esta función generadora en un tiempo aleatorio entre min y maxTime
	}
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "StopObstaclesGen");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && firstGenerated == true) {
			//Si es la primera vez que pulso el botón del ratón genero. Para evitar generar en cada click
			Generate ();
		}
	}
}
