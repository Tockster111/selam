using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {
	public Text ScoreToString;
	public int nilai;
	// Use this for initialization
	void Start () {
		nilai = 0;
		ScoreToString = GameObject.Find ("Score").GetComponent<Text> ();
		ScoreToString.text = nilai + "/10";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
