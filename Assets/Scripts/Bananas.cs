using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bananas : MonoBehaviour {


	public delegate void BananasDestroyed ();
	public static event BananasDestroyed OnBananasDestroy;

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D collision) {
		Debug.Log ("Collision!");
		destroyBananas ();
	}

	void destroyBananas() {
		if (OnBananasDestroy != null) {
			OnBananasDestroy ();
		}
		Destroy (gameObject);
	}
}
