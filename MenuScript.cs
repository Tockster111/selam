using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour {
	public bool isPaused;
	public GameObject MainMenu;
	public GameObject FreeMode;
	public GameObject Pengaturan;
	public GameObject Credits;
	public GameObject currentlyOpen;
	public GameObject music;
	public CanvasGroup Menu;
	public GameObject selam;
	private Color selam1;
	public GameObject sea;
	private Color sea1;
	public AudioSource bubbleAudio;
	// Use this for initialization
	private ParticleSystem _CachedSystem;
	ParticleSystem system
	{
		get
		{
			if (_CachedSystem == null)
				_CachedSystem = GameObject.Find("Bubble Menu Effect").GetComponent<ParticleSystem>();
			return _CachedSystem;
		}
	}
	void Start () {
		isPaused = false;
		FreeMode.SetActive (false);
		Pengaturan.SetActive (false);
		MainMenu.SetActive (true);
		Credits.SetActive (false);
		Menu = MainMenu.GetComponent <CanvasGroup> ();
		selam1 = selam.GetComponent<SpriteRenderer> ().color;
		sea1 = sea.GetComponent<SpriteRenderer> ().color;
		//selam1.a = 0;
		//sea1.a = 0;
		selam.GetComponent<SpriteRenderer> ().color = selam1;
		sea.GetComponent<SpriteRenderer> ().color = sea1;
		ParticleSystem.EmissionModule em = system.emission;
		em.enabled = false;
		bubbleAudio = GameObject.Find ("Bubble Menu Effect").GetComponent<AudioSource> ();
		bubbleAudio.Pause();
		if (GameObject.FindGameObjectWithTag("Music") == null) {
			Instantiate (music);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			//setactive true
			ParticleSystem.EmissionModule em = system.emission;
			em.enabled = true;
			bubbleAudio.UnPause ();
		}
		else {
			//setactive false
			ParticleSystem.EmissionModule em = system.emission;
			em.enabled = false;
			bubbleAudio.Pause();
		}
	}
	public void setVolumeBar (float volume)
	{
		AudioListener.volume = volume;
	}
	public void ModeBebas ()
	{
		currentlyOpen = FreeMode;
		FreeMode.SetActive (true);
		//MainMenu.SetActive (false);
		Menu.alpha = 0;
	//	selam1.a = 0;
	//	sea1.a = 1;
		selam.GetComponent<SpriteRenderer> ().color = selam1;
		sea.GetComponent<SpriteRenderer> ().color = sea1;
		sea.transform.position =  selam.transform.position + new Vector3 (0, 0, -1);
	}
	public void BukaPengaturan ()
	{
		currentlyOpen = Pengaturan;
		Pengaturan.SetActive (true);
		//MainMenu.SetActive (false);
		Menu.alpha = 0;
	//	selam1.a = 0;
	//	sea1.a = 1;
		selam.GetComponent<SpriteRenderer> ().color = selam1;
		sea.GetComponent<SpriteRenderer> ().color = sea1;
		sea.transform.position =  selam.transform.position + new Vector3 (0, 0, -1);
	}
	public void goBack ()
	{	
		currentlyOpen.SetActive (false);
		//MainMenu.SetActive (true);
		Menu.alpha = 1;
	//	selam1.a = 1;
	//	sea1.a = 0;
		selam.GetComponent<SpriteRenderer> ().color = selam1;
		sea.GetComponent<SpriteRenderer> ().color = sea1;
		sea.transform.position =  selam.transform.position + new Vector3 (0, 0, 1);
	}
	public void keluar ()
	{	
		Application.Quit ();
	}
	public void levelBahasa ()
	{	
		SceneManager.LoadScene (1);
	}
	public void rantaiMakanan ()
	{	Destroy (GameObject.Find ("Continuum").gameObject);
		SceneManager.LoadScene (2);
	}
	public void menuTrivia ()
	{	
		SceneManager.LoadScene (3);
	}
	public void openCredits()
	{
		currentlyOpen = Credits;
		Credits.SetActive (true);

		//MainMenu.SetActive (false);
		Menu.alpha = 0;
	//	selam1.a = 0;
	//	sea1.a = 1;
		selam.GetComponent<SpriteRenderer> ().color = selam1;
		sea.GetComponent<SpriteRenderer> ().color = sea1;
		sea.transform.position = selam.transform.position + new Vector3 (0, 0, -1);
	}
}
