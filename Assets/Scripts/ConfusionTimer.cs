using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfusionTimer : MonoBehaviour {

	public delegate void TimeIsUp ();
	public static event TimeIsUp OnTimeIsUp;

	static bool active = false;
	public static float timeLeft = 15.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			timeLeft -= Time.deltaTime;
			if ( timeLeft < 0 ) {
				active = false;
				if (OnTimeIsUp != null) {
					OnTimeIsUp ();
				}
			}
		}
	}

	public static void startTimer() {
		active = true;
	}
}
