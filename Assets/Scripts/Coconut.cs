using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour {


	public int TURTLE_LAYER = 8;
	public int BANANAS_LAYER = 9;
	public int NONE_LAYER = 10;

	public bool hitBananas = false;
	public bool hitTurtle = false;
	public bool disabled = false;

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D collision) {

		if (collision.gameObject.name == "Turtle") {
			hitTurtle = true;
			gameObject.layer = BANANAS_LAYER;
		}
		if (collision.gameObject.name == "Bananas(Clone)") {
			Debug.Log ("Hit Banana!");
			hitBananas = true;
			disabled = true;
			gameObject.layer = NONE_LAYER;
		}
	}
}
