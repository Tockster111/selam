using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Ans : MonoBehaviour {
	public int ChainValue;
	//for enter
	public bool mouseEnter =false;
	//--------------------------------
	public Vector2 mouseStartPos;
	Vector2 previousPosition;
	public bool mouseUp ;
	public bool BackToOriginalPos;
	public GameObject next;
	public GameObject iterator;
	private LineRenderer lineRenderer;
	public GameObject arrow;
	private GameObject instantiatedArrow;
	public float angle;
	public float LayerOffset;
	// Use this for initialization
	void Start () {
		previousPosition = transform.position;
		mouseUp = true;
		BackToOriginalPos = true;
		lineRenderer = GetComponent<LineRenderer> ();

	}

	// Update is called once per frame
	void Update () {
		
		if (next != null) {
			Debug.DrawLine (this.gameObject.transform.position, next.gameObject.transform.position);
			lineRenderer.SetPosition (0, new Vector3 (transform.position.x, transform.position.y, LayerOffset ));
			lineRenderer.SetPosition (1, new Vector3 (next.gameObject.transform.position.x, next.gameObject.transform.position.y, LayerOffset ));
			if (instantiatedArrow == null) {
				//next.y - this.y, next.x, this.x
				Vector3 vec = new Vector3 (next.gameObject.transform.position.x,next.gameObject.transform.position.y,-2f);
				instantiatedArrow = Instantiate (arrow, vec, Quaternion.identity, this.gameObject.transform);
			}
			else {
				float lineAngle = Mathf.Atan2 (-next.transform.position.y + transform.position.y, -next.transform.position.x + transform.position.x) * 180 / Mathf.PI;
				angle = lineAngle;
				instantiatedArrow.transform.rotation = Quaternion.Euler (0, 0, lineAngle);
				Debug.Log ("Create Arrow");
			}
		}
		else {
			lineRenderer.SetPosition (0, new Vector3 (transform.position.x, transform.position.y, LayerOffset ));
			lineRenderer.SetPosition (1, new Vector3 (transform.position.x, transform.position.y, LayerOffset ));
			if (instantiatedArrow != null) {
				Debug.Log ("Destroy arrow");
				Destroy (instantiatedArrow.gameObject);
				instantiatedArrow = null;
			}
		}

		if (mouseEnter) {
			if (Input.GetMouseButtonUp (0)) {
				if (this.next == null&&GameObject.Find ("Enter").GetComponent <Level2Enter> ().hold!=this.gameObject) {
						GameObject.Find ("Enter").GetComponent <Level2Enter> ().hold.GetComponent<Level2Ans> ().next = this.gameObject;

				}
				GameObject.Find ("Enter").GetComponent <Level2Enter> ().hold = null;
			

			}
		}
		else {
			if (GameObject.Find ("Enter").GetComponent <Level2Enter> ().hold != null) {
				GameObject.Find ("Enter").GetComponent <Level2Enter> ().hold.GetComponent<Level2Ans> ().next = null;


			}
			else {
				GameObject.Find ("Enter").GetComponent <Level2Enter> ().hold = null;//new

			}
		}

		if (iterator != null&& this.gameObject == GameObject.Find ("Enter").GetComponent<Level2Enter>().hold) {

		}
		if (mouseUp && BackToOriginalPos) {
			transform.position = previousPosition;
			BackToOriginalPos = false;
		}
	}
	void OnMouseDown()
	{


	}
	void OnMouseDrag()
	{	
		GameObject.Find ("Enter").GetComponent <Level2Enter> ().hold = this.gameObject;
		mouseStartPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Debug.DrawLine (mouseStartPos, this.gameObject.transform.position);

		/*BackToOriginalPos = true;
		if (!GameObject.Find ("Canvas").GetComponent <PauseScript> ().isPaused && !GameObject.Find ("Enter").GetComponent <Level2Enter> ().isWin) {
			mouseUp = false;
			mouseStartPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = mouseStartPos;
		}*/

	}
	void OnMouseUp()
	{	
		mouseUp = true;
		
		// instantiate mouse point
		//
	}
	void OnMouseExit()
	{
		mouseEnter = false;
	}
	void OnMouseEnter()
	{	mouseEnter = true;
		

	}
	void OnTriggerExit2D (Collider2D col)
	{	
		/*if (col.tag.Equals ("AnsBox") && mouseUp) {
			
			BackToOriginalPos = false;
			Debug.Log ("Jalan");
			if (col.gameObject.GetComponent <Level2Box> ().AnswerObject == null) {
				transform.position = col.gameObject.transform.position;
				col.gameObject.GetComponent <Level2Box> ().playerAnswer = this.ChainValue;
				col.gameObject.GetComponent <Level2Box> ().AnswerObject = this.gameObject;
			} else {
				BackToOriginalPos = true;
				col.gameObject.GetComponent <Level2Box> ().playerAnswer = -1;
				col.gameObject.GetComponent <Level2Box> ().AnswerObject = null;
			}
		}
		else  {
			BackToOriginalPos = true;
		}*/

	}
	void OnTriggerEnter2d(Collider2D col)
	{
		
	}
}
