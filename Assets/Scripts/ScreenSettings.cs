using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSettings : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Screen.SetResolution (2560, 1600, true);
	}
}
