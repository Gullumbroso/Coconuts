using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour {

	private float MAX_POS = 11.0f;
	private float MIN_POS = -11.0f;
	private float INIT_Y_POS = -5.5f;

	private bool moveLeft;
	private bool moveRight;
	private float rotation;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		getInput ();
	}

	void getInput () {
		float posX = transform.position.x;
		Vector3 newPos = new Vector3(posX, transform.position.y, 0);

		if (Input.GetKey (KeyCode.LeftArrow) && posX > MIN_POS) {
			posX -= 0.2f;
		}
		if (Input.GetKey (KeyCode.RightArrow) && posX < MAX_POS) {
			posX += 0.2f;
		}
			
		newPos = new Vector3(posX, calcY(posX) + INIT_Y_POS, 0);
		transform.position = newPos;
		rotation = posX * 3.0f;
		transform.rotation = Quaternion.Euler (0, 0, rotation);
	}

	float calcY(float x) {
		return 0.022f * (float) System.Math.Pow (x, 2);
	}

	public float getRotation() {
		return rotation;
	}
}
