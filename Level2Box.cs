using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Box : MonoBehaviour {
	public int chainValue;
	public int playerAnswer;
	public GameObject AnswerObject;
	// Use this for initialization
	void Start () {
		playerAnswer = -1;
		AnswerObject = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (AnswerObject != null) {
			if (AnswerObject.GetComponent <Level2Ans> ().BackToOriginalPos) {
				playerAnswer = -1;
				AnswerObject = null;
			}
		}
	}
	void OnTriggerEnter2d(Collider2D col)
	{
		if (col.gameObject.CompareTag ("DragableAns")) {
			playerAnswer = col.gameObject.GetComponent <Level2Ans> ().ChainValue;
			AnswerObject = col.gameObject;
		}
	}
	void OnTriggerExit2d(Collider2D col)
	{
		if (col.gameObject.CompareTag ("DragableAns")) {
			playerAnswer = -1;
			AnswerObject = null;
		}
	}
}
