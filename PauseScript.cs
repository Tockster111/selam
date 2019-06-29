using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseScript : MonoBehaviour {
	public bool isPaused;
	public GameObject Tutorial;

	public GameObject currentlyOpen;
	// Use this for initialization
	void Start () {
		isPaused = true;
		Tutorial.SetActive (true);
		currentlyOpen = Tutorial;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Panduan ()
	{	isPaused = true;
		currentlyOpen = Tutorial;
		Tutorial.SetActive (true);
	}
	public void BukaPengaturan ()
	{
		
	}
	public void goBack ()
	{	isPaused = false;
		Time.timeScale = 1f;
		currentlyOpen.SetActive (false);

	}
	public void keluar ()
	{	
		Application.Quit ();
	}

}
