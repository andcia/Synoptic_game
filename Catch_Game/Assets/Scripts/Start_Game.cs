using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Game : MonoBehaviour {

	public GameController gameController;

	void OnMouseDown()
	{
		gameController.StartGame();
	}
}
