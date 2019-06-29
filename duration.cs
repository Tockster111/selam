using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duration : MonoBehaviour {
	public float counter;
	private float stopwatch;
	// Use this for initialization
	void Start () {
		stopwatch = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		stopwatch += Time.deltaTime;
		if (stopwatch >= counter) {
			Destroy (this.gameObject);
		}
	}
}
