using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat_controller : MonoBehaviour {

	public Camera cam;

	private float maxWidth;

	public Renderer rend;

	// Use this for initialization
	void Start () {

		if (cam == null)
		{
			cam = Camera.main;//using the same camera towards screen world.
		}
		rend = GetComponent<Renderer>();

		Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);//knowing the position of the screen upper corner
		Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
		float hatWidth = rend.bounds.extents.x;
		maxWidth = targetWidth.x - hatWidth;
	}
	
	// Update is called once physics timestep
	void FixedUpdate () {

		Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);// follows the path of the mouse right and left on the screen
		Vector3 targetPosition = new Vector3(rawPosition.x, 0.0f, 0.0f);
		float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);//Everything is centered on the center screen on the scene therefore our target position is able to set.
		targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.x);//clamping the target postion between x and y
		GetComponent<Rigidbody2D>().MovePosition(targetPosition);// the movement (mouse)
		
	}
}
