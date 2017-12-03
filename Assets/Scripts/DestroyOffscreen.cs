using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffscreen : MonoBehaviour {

	public float offset = 10f;
	public Spawner spwaner;
	public Camera cam;

	public delegate void CoconutDestroyed ();
	public static event CoconutDestroyed OnCocoDestroy;

	private bool offscreen = false;
	private float yOffset;

	void Awake () {
		cam = Camera.main;
		yOffset = -(cam.orthographicSize);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var posY = transform.position.y;

		if (posY < (yOffset - offset)) {
			offscreen = true;
		} else {
			offscreen = false;
		}

		if (offscreen) {
			OnOutOfBounds ();
		}
	}

	public void OnOutOfBounds() {
		if (OnCocoDestroy != null) {
			OnCocoDestroy ();
		}
		offscreen = false;
		Destroy (gameObject);
	}
}
