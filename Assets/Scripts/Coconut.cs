using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour {


	public int TURTLE_LAYER = 8;
	public int BANANAS_LAYER = 9;

	public bool hitBananas = false;
	public bool hitTurtle = false;
	public bool disabled = false;
	BoxCollider2D coll2d;

	// Use this for initialization
	void Awake () {
		coll2d = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (disabled) {
			Destroy (coll2d);
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {

		if (collision.gameObject.name == "Turtle") {
			hitTurtle = true;
			gameObject.layer = BANANAS_LAYER;
		}
		if (collision.gameObject.name == "Bananas(Copy)") {
			hitBananas = true;
			disabled = true;
			Debug.Log ("Hit bananas!");
		}
	}
}
