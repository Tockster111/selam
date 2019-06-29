using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour {
	public Vector2 WorldMouse;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		WorldMouse = Camera.main.ScreenToWorldPoint (Input.mousePosition - transform.position);
		transform.position = WorldMouse;
	}
}
