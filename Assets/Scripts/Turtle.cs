using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour {

	float MAX_ANGLE = 35.0f;
	float MIN_ANGLE = -35.0f;
	float MOVEMENT_OFFSET_DIV = -150f;
	float MONKEY_ANGLE_OFFSET_DIV = 50f;
	float MONKEY_HEIGHT = 1.45f;
	float MONKEY_X_OFFSET = 0.75f;

	private float rotation = 0f;
	public GameObject monkey;
	public Monkey monkeyScript;

	// Use this for initialization
	void Awake () {
		monkey = GameObject.Find ("Monkey");
	
	}
	
	// Update is called once per frame
	void Update () {

		getInput ();
	}

	void getInput() {

		if (Input.GetKey (KeyCode.A) && rotation < MAX_ANGLE) {
			rotation += 2.5f;
		}
		if (Input.GetKey (KeyCode.D) && rotation > MIN_ANGLE) {
			rotation -= 2.5f;
		}

		float monkeyAngle = monkey.transform.rotation.eulerAngles.z;
		monkeyAngle = (monkeyAngle > 180) ? monkeyAngle - 360 : monkeyAngle;
		var offset = rotation / MOVEMENT_OFFSET_DIV;
			
		offset -= (monkeyAngle / MONKEY_ANGLE_OFFSET_DIV);

		var monkeyPos = monkey.transform.position;
		Vector3 newPos = new Vector3(monkeyPos.x + offset, monkeyPos.y + MONKEY_HEIGHT, monkeyPos.z);

		transform.position = newPos;
		float newRotation = rotation + monkeyAngle;
		transform.rotation = Quaternion.Euler (0, 0, newRotation);
	}
}
