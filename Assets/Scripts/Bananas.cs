using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bananas : MonoBehaviour {


	public delegate void BananasDestroyed ();
	public static event BananasDestroyed OnBananasDestroy;

	float DESTROY_TIMER = 2.4f;

	Animator animator;
	Rigidbody2D body2d;
	AudioSource[] sounds;
	SpriteRenderer sprite;

	bool destroy = false;
	float destroyTimer;

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator> ();
		body2d = GetComponent<Rigidbody2D> ();
		sounds = GetComponents<AudioSource> ();
		sprite = GetComponent<SpriteRenderer> ();
		destroyTimer = 0;
	}

	// Update is called once per frame
	void Update () {
		if (destroy) {
			destroyTimer -= Time.deltaTime;
			if (destroyTimer < 0) {
				Destroy (gameObject);
			} else if (destroyTimer < DESTROY_TIMER / 2.0f && sprite != null) {
				if (OnBananasDestroy != null) {
					OnBananasDestroy ();
				}
				Destroy (sprite);
				sprite = null;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		destroyBananas ();
	}

	void destroyBananas() {
		sounds [1].Play ();
		Destroy (body2d);
		gameObject.layer = 10; // None
		Vector3 pos = transform.position;
		transform.position = new Vector3 (pos.x + 0.65f, pos.y - 6.0f);
		animator.SetTrigger ("Explode");
		destroy = true;
		destroyTimer = DESTROY_TIMER;
	}
}
