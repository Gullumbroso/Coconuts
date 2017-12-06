using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour {


	public int TURTLE_LAYER = 8;
	public int BANANAS_LAYER = 9;
	public int NONE_LAYER = 10;
	private float torqueMagnitude;
	private AudioSource cocoSound;

	public bool hitBananas = false;
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
		torqueMagnitude = Random.Range (1500.0f, -1500.0f);
		body2d.AddTorque (torqueMagnitude * Time.deltaTime);
	}

	void OnCollisionEnter2D (Collision2D collision) {

		setNewTorque ();

		if (collision.gameObject.name == "Turtle") {
			hitTurtle = true;
			gameObject.layer = BANANAS_LAYER;
			cocoSound.Play();
		}
		if (collision.gameObject.name == "Bananas(Clone)") {
			hitBananas = true;
			disabled = true;
			transform.localScale = new Vector3 (0, 0, 0);
		}
	}
}
