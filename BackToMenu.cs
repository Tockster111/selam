using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
public class BackToMenu : MonoBehaviour {
	public int level;
	[SerializeField] private string AppID = "ca-app-pub-8761413275668713~1892932375";
	[SerializeField] private string InterstitialID = "ca-app-pub-8761413275668713/2714650339";
	private InterstitialAd regAd;
	private int adCounter;
	// Use this for initialization
	private void RequestInterstitialAd()
	{
		regAd = new InterstitialAd (InterstitialID);
		AdRequest request = new AdRequest.Builder().Build();
		regAd.LoadAd (request);


	}
	void Start () {
		RequestInterstitialAd ();
		adCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void KeMenu ()
	{	if (GameObject.Find ("Music") != null) {
			Destroy (GameObject.Find ("Music"));
		}
		if (adCounter < 1) {
			while (!regAd.IsLoaded()) {
				Debug.Log ("Wait");
			}
			if (regAd.IsLoaded ()) {
				regAd.Show ();
			}
			adCounter++;
		}
		else {
			Time.timeScale = 1f;
			SceneManager.LoadScene (0);	
		}

	}
	public void Lanjutkan ()
	{	if (adCounter < 1) {
			while (!regAd.IsLoaded()) {
				Debug.Log ("Wait");
			}
			if (regAd.IsLoaded ()) {
				regAd.Show ();
			}
			adCounter++;
		}
		else {
			if (level == 1) {
				SceneManager.LoadScene (2);
			}
			else {
				SceneManager.LoadScene (1);
			}
		}

		
	}
	public void Retry ()
	{	if (adCounter < 1) {
			while (!regAd.IsLoaded()) {
				Debug.Log ("Wait");
			}
			if (regAd.IsLoaded ()) {
				regAd.Show ();
			}
			adCounter++;
		}
		else {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
	}
}
