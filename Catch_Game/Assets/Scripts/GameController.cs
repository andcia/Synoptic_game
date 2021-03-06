﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Camera cam;
	public GameObject[] ball;
	public float timeLeft;
	public Text timerText;
	public GameObject gameOverText;
	public GameObject restartButton;
	public GameObject splashScreen;
	public GameObject startButton;
	public Hat_controller hatController;

	private float maxWidth;
	private bool counting;

	// Use this for initialization
	void Start()
	{
		if (cam == null)
		{
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
		float ballWidth = ball[0].GetComponent<Renderer>().bounds.extents.x;
		timerText.text = "Time:\n" + Mathf.RoundToInt(timeLeft);
		maxWidth = targetWidth.x - ballWidth;
	}

	void FixedUpdate()
	{
		if (counting)
		{
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0)
			{
				timeLeft = 0;
			}
			timerText.text = "TIME LEFT:\n" + Mathf.RoundToInt(timeLeft);
		}
	}

	public void StartGame()
	{
		splashScreen.SetActive(false);
		startButton.SetActive(false);
		StartCoroutine(Spawn());
		timerText.text = "TIME LEFT:\n" + Mathf.RoundToInt(timeLeft);
	}

	public IEnumerator Spawn()
	{
		yield return new WaitForSeconds(2.0f);
		counting = true;
		while (timeLeft > 0)
		{
			GameObject balls = ball[Random.Range(0, ball.Length)];
			Vector3 spawnPosition = new Vector3(
				transform.position.x + Random.Range(-maxWidth, maxWidth),
				transform.position.y,
				0.0f
			);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate(balls, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
		}
		yield return new WaitForSeconds(2.0f);
		gameOverText.SetActive(true);
		yield return new WaitForSeconds(2.0f);
		restartButton.SetActive(true);
	}
}