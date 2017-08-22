using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public Camera cam;
	public GameObject[] ball;
	private Renderer rend;

	public float timeLeft;

	private float maxWidth;

	// Use this for initialization
	void Start()
	{

		if (cam == null)
		{
			cam = Camera.main;//using the same camera towards screen world.
		}
		rend = GetComponent<Renderer>();

		Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);//knowing the position of the screen upper corner
		Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);//Locating the whole screen and with the ScreenToWorld value upperCorner we can determine the outcome position of the camera
		float ballWidth = ball[0].GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;
		StartCoroutine(Spawn());
	}

	void FixedUpdate() {
		timeLeft -= Time.deltaTime;
	}
	IEnumerator Spawn()
	{
		yield return new WaitForSeconds(2.0f);//giving the player some setup time frame to adjust the controls before the game commences with the balls
		while (timeLeft > 0)
		{
			Vector3 spawnPosition = new Vector3(
				Random.Range(-maxWidth, maxWidth),
				transform.position.y,
				0.0f);//Gameobjects location X,Y,Z
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate<GameObject>(ball[0], spawnPosition, spawnRotation);

			//Asking unity to stop the loop and return new random range
			yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
		}
	}
}
