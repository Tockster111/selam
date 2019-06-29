using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSound : MonoBehaviour {
	Button button;
	public AudioClip clip;
	AudioSource source;
	// Use this for initialization
	void Start () {
		button = GetComponent <Button> ();
		source = GetComponent<AudioSource> ();
		source.clip = clip;
		source.playOnAwake = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void playSound()
	{
		source.PlayOneShot (clip);
	}
}
