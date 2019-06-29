using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLineRenderer : MonoBehaviour {
	private LineRenderer lineRenderer;
	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent <LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			if (GameObject.Find ("Enter").GetComponent <Level2Enter> ().hold!=null) {
				Vector2 mouseStartPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Debug.DrawLine (mouseStartPos, GameObject.Find ("Enter").GetComponent <Level2Enter> ().hold.transform.position);
				lineRenderer.SetPosition (0, GameObject.Find ("Enter").GetComponent <Level2Enter> ().hold.transform.position);
				lineRenderer.SetPosition (1, mouseStartPos);
			}
		}
		else {
			lineRenderer.SetPosition (0, transform.position);
			lineRenderer.SetPosition (1, transform.position);
		}
	}
	void OnMouseDrag()
	{	
		

	}
}
