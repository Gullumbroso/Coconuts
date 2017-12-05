using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottenCoconut : MonoBehaviour {

	private float torqueMagnitude;
	private AudioSource cocoSound;

	public delegate void RottenCocoHit ();
	public static event RottenCocoHit OnRottenCocoHit;

	public bool hitTurtle = false;
	public bool disabled = false;

	private Rigidbody2D body2d;

	// Use this for initialization
	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
		cocoSound = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Start () {
		setNewTorque ();
	}

	void FixedUpdate() {

	}

	void setNewTorque() {
		torqueMagnitude = Random.Range (500.0f, -500.0f);
		body2d.AddTorque (torqueMagnitude * Time.deltaTime);
	}

	void OnCollisionEnter2D (Collision2D collision) {

		setNewTorque ();

		if (collision.gameObject.name == "Turtle") {
			hitTurtle = true;
			cocoSound.Play();
			if (OnRottenCocoHit != null) {
				OnRottenCocoHit ();
			}
			gameObject.layer = 10; // None Layer
		}
	}
}
