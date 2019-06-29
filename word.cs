using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class word : MonoBehaviour {
	
	public string Animal;
	public Vector2 mouseStartPos;
	Vector2 previousPosition;
	public bool mouseUp ;
	public bool BackToOriginalPos;
	// Use this for initialization
	void Start () {
		previousPosition = transform.position;
		mouseUp = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (mouseUp)
			transform.position = previousPosition;
	}
	void OnMouseDrag()
	{	if (!GameObject.Find ("Canvas").GetComponent <PauseScript> ().isPaused&&!GameObject.Find ("Enter").GetComponent <Enter>().isWin)
		{
			mouseUp = false;
			mouseStartPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = mouseStartPos;	
		}
	}
	void OnMouseUp()
	{	mouseUp = true;
		

	}
	void OnTriggerExit2D (Collider2D col)
	{	
		if (col.tag.Equals ("Language")&&mouseUp&&col.gameObject.GetComponent<Language>().KeyAnswer== this.Animal) {
			
			//Debug.Log ("Jalan");
			col.gameObject.GetComponent <TextMesh> ().text = this.GetComponent<TextMesh> ().text;
			col.gameObject.GetComponent <Language> ().answer = this.GetComponent<TextMesh> ().text;
			BackToOriginalPos = true;
		}
	
	}
}
