using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffscreen : MonoBehaviour {

	public float offset = -10f;
	public Spawner spwaner;
	public Camera cam;

	public delegate void CoconutDestroyed ();
	public static event CoconutDestroyed OnCocoDestroy;
	public Coconut cocoScript;
	public RottenCoconut rottenCocoScript;

	private bool offscreen = false;
	private float yOffset;

	void Awake () {
		cam = Camera.main;
		yOffset = cam.orthographicSize;
	}

	// Use this for initialization
	void Start () {
		if (gameObject.name == "Coconut(Clone)") {
			cocoScript = gameObject.GetComponent<Coconut> ();
		} else if (gameObject.name == "Rotten Coconut(Clone)") {
			rottenCocoScript = gameObject.GetComponent<RottenCoconut> ();
		} else {
			Debug.Log("Something is wrong in the Start method of DestoryOffscreen");
		}
	}
	
	// Update is called once per frame
	void Update () {
		var posY = transform.position.y;
		if (cocoScript != null) {
			// This is a regular coconut
			if (cocoScript.hitTurtle && posY > yOffset + 1.0f) {
				offscreen = true;
			} else if (posY < (-(yOffset) - offset)) {
				offscreen = true;
			} else {
				offscreen = false;
			}

			if (offscreen) {
				OnOutOfBounds ();
			}
		} else if (rottenCocoScript != null) {
			// This is a rotten coconut
			if (rottenCocoScript.hitTurtle && posY > yOffset + 1.0f) {
				offscreen = true;
			} else if (posY < (-(yOffset) - offset)) {
				offscreen = true;
			} else {
				offscreen = false;
			}

			if (offscreen) {
				OnOutOfBounds ();
			}
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
