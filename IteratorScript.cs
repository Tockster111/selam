using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IteratorScript : MonoBehaviour {
	public GameObject originalObject;
	public Vector2 WorldMouse;
	public bool followCursor;
	public bool mouseUp;
	// Use this for initialization
	void Start () {
		followCursor = true;
		mouseUp = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDrag()
	{
		mouseUp = false;
	}
	void OnMouseUp()
	{
		mouseUp = true;
	}
	void OnTriggerStay2D (Collider2D col)
	{
		if (col.CompareTag ("DragableAns")&&col.gameObject!=originalObject) {
			originalObject.GetComponent <Level2Ans> ().next = this.gameObject;
			followCursor = false;
		}
	}
}
