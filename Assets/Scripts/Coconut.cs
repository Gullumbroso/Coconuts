using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour {

	public bool active = true;
	BoxCollider2D coll2d;
	public GameObject turtle;

	// Use this for initialization
	void Awake () {
		coll2d = GetComponent<BoxCollider2D> ();
		turtle = GameObject.Find ("Turtle");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D collision) {

		Physics2D.IgnoreCollision (coll2d, turtle.GetComponent<BoxCollider2D> ());
		active = false;
	}
}
