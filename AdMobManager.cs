using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class AdMobManager : MonoBehaviour {
	[SerializeField] private string AppID = "ca-app-pub-8761413275668713~1892932375";
	[SerializeField] private string InterstitialID = "ca-app-pub-8761413275668713/2714650339";
	// Use this for initialization
	private void Awake ()
	{
		MobileAds.Initialize (AppID);
	}
	void Start () {
		
	}
	public void OnClickSomeButton()
	{
		RequestInterstitialAd ();

	}
	private void RequestInterstitialAd()
	{
		InterstitialAd regAd = new InterstitialAd (InterstitialID);
		AdRequest request = new AdRequest.Builder().Build();
		regAd.LoadAd (request);
		if (regAd.IsLoaded ()) {
			regAd.Show ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
