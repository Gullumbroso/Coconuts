using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	private int COCO_IDX = 0;
	private int BANANAS_IDX = 1;
	private int ROTTEN_COCO_IDX = 2;
	private float COCO_DROP_HEIGHT = 8.3f;
	private float BANANAS_HEIGHT = 6.0f;
	private int MAX_COCOS_SIMULT = 1;
	private int MAX_BANANAS_SIMULT = 1;

	public GameObject[] prefabs;
	public bool active = true;

	public GameObject bananas;

	private int numOfCocos = 0;
	private int numOfBananas = 0;
	private float screenWidthRange;
	private float prefabsOffset = 3.0f;

	void OnEnable() {
		Bananas.OnBananasDestroy += bananasDestroyed;
		DestroyOffscreen.OnCocoDestroy += cocoDestroyed;
	}

	void OnDisable() {
		Bananas.OnBananasDestroy -= bananasDestroyed;
		DestroyOffscreen.OnCocoDestroy -= cocoDestroyed;
	}

	// Use this for initialization
	void Start () {
		screenWidthRange = Camera.main.orthographicSize * Camera.main.aspect;
		spawnBananas ();
		spawnCoconut ();
	}
	
	// Update is called once per frame
	void Update () {
		if (numOfBananas < MAX_BANANAS_SIMULT) {
			spawnBananas ();
		}
		if (numOfCocos < MAX_COCOS_SIMULT && numOfBananas > 0) {
			spawnCoconut ();
		} 
	}

	public void bananasDestroyed() {
		numOfBananas--;
	}

	public void cocoDestroyed() {
		numOfCocos--;
	}
		
	public void spawnBananas() {
		numOfBananas++;
		Vector3 position = new Vector3(Random.Range(-(screenWidthRange - prefabsOffset), screenWidthRange - prefabsOffset), BANANAS_HEIGHT);
		Instantiate(prefabs[BANANAS_IDX], position, Quaternion.identity);
	}

	public void spawnCoconut() {
		numOfCocos++;

		bananas = GameObject.Find ("Bananas(Clone)");
		PolygonCollider2D bananasColl = bananas.GetComponent<PolygonCollider2D> ();
		float bananasSize = bananasColl.bounds.size.x;
		float bananasPos = bananasColl.transform.position.x;

		Vector3 position = new Vector3(getDropSpot(bananasSize, bananasPos), COCO_DROP_HEIGHT);

		int lotto = Random.Range (0, 100);
		int cocoTypeIdx = lotto > 25 ? COCO_IDX : ROTTEN_COCO_IDX;
		Instantiate(prefabs[cocoTypeIdx], position, Quaternion.identity);
	}

	float getDropSpot(float size, float pos) {

		float offset = 1.0f;

		float leftBound1 = System.Math.Max (-(screenWidthRange - prefabsOffset), pos - size - offset);
		float rightBound1 = System.Math.Max (-(screenWidthRange - prefabsOffset), pos - (size / 2.0f));
		float result1 = Random.Range (leftBound1, rightBound1);

		float leftBound2 = System.Math.Min (screenWidthRange - prefabsOffset, pos + (size / 2.0f));
		float rightBound2 = System.Math.Min (screenWidthRange - prefabsOffset, pos + size + offset);
		float result2 = Random.Range (leftBound2, rightBound2);

		int lotto = Random.Range (0, 2);
		if (lotto == 0) {
			return result1;
		} else {
			return result2;
		}

	}
}
