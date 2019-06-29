using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
public class MainMenuDecision : MonoBehaviour {
	public GameObject Decision;
	[SerializeField] private string AppID = "ca-app-pub-8761413275668713~1892932375";
	[SerializeField] private string InterstitialID = "ca-app-pub-8761413275668713/2714650339";
	InterstitialAd regAd;
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
		Decision.SetActive (false);	
		adCounter = 0;
	}
	public void OpenDecision()
	{	
		
		Decision.SetActive (true);
	}
	public void YesMenu()
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
			SceneManager.LoadScene (0);
		}
	}
	public void NoMenu ()
	{
		Decision.SetActive (false);
	
	}
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator holdTime ()
	{
		yield return new WaitForSeconds (2f);

	}
}
