using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TriviaSystem : MonoBehaviour {
	public Text name;
	public Text chain;
	public Text trivia;
	public GameObject [] Picture;
	public GameObject currentObject;
	public int index;
	private ParticleSystem _CachedSystem;
	public AudioSource bubbleAudio;
	ParticleSystem system
	{
		get
		{
			if (_CachedSystem == null)
				_CachedSystem = GameObject.Find("Bubble Menu Effect").GetComponent<ParticleSystem>();
			return _CachedSystem;
		}
	}
	// Use this for initialization
	void Start () {
		index = 0;
		currentObject = Instantiate (Picture [index], GameObject.Find ("AnimalSpawn").transform.position, Quaternion.identity, GameObject.Find ("ParentForAnimation").transform);
		ObtainPictureProperties ();
		bubbleAudio = GameObject.Find ("Bubble Menu Effect").GetComponent<AudioSource> ();
		bubbleAudio.Pause();
	}
	public void next ()
	{
		index++;
		if (index > Picture.Length - 1) {
			index = 0;		
		}
		DestroyCurrentTriviaImage ();
		currentObject = Instantiate (Picture [index], GameObject.Find ("AnimalSpawn").transform.position, Quaternion.identity, GameObject.Find ("ParentForAnimation").transform);
		ObtainPictureProperties ();
	}
	public void prev ()
	{	index--;
		if (index < 0) {
			index = Picture.Length - 1;
		}
		DestroyCurrentTriviaImage ();
		currentObject =Instantiate (Picture [index], GameObject.Find ("AnimalSpawn").transform.position, Quaternion.identity, GameObject.Find ("ParentForAnimation").transform);
		ObtainPictureProperties ();
	}
	void DestroyCurrentTriviaImage()
	{
		GameObject toDestroy = GameObject.FindGameObjectWithTag ("TriviaImage");
		Destroy (toDestroy.gameObject);
	}
	public void ChangeName()
	{
		name.text = currentObject.GetComponent <PictureTriviaScript> ().name;
	}
	public void ChangeTrivia()
	{
		trivia.text = currentObject.GetComponent <PictureTriviaScript> ().children.GetComponent<Text>().text;
	}
	public void ChangeChain()
	{
		chain.text = currentObject.GetComponent <PictureTriviaScript> ().rantaiMakanan;
	}
	public void ObtainPictureProperties()
	{
		ChangeName ();
		ChangeTrivia ();
		ChangeChain ();
	}
	public void BackToMenu()
	{
		SceneManager.LoadScene (0);
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
}
