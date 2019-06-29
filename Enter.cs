using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour {
	public string[] AnimalList;
	public GameObject id;
	public GameObject en;
	GameObject Score;
	public GameObject[] word;						
	public GameObject[] Picture;
	public List <int> usedValuePictures = new List <int> ();
	public List <int> usedValues = new List <int> ();// ini adalah kotak jawaban supaya tidak ditaruh di kotak yg sama		
	public List <string> usedAnswers = new List <string> ();//ini buat supaya jawaban tidak diulang
	//GameObject a;
	public GameObject particle;
	public GameObject WinPanel;
	public GameObject Flip;
	public GameObject TrueEffects;
	public bool isWin;

	//===============================
	public GameObject music;
	//=======================
	public AudioClip clip;
	private AudioSource source;
	//=============================
	private ParticleSystem _CachedSystem;
	ParticleSystem system
	{
		get
		{
			if (_CachedSystem == null)
				_CachedSystem = GameObject.Find("Cursor Hover Effect").GetComponent<ParticleSystem>();
			return _CachedSystem;
		}
	}
	void playSound()
	{
		source.PlayOneShot (clip);
		source.loop = false;
	}
	//===============================
	// Use this for initialization
	void Start () {
		id = GameObject.Find ("Indonesia");
		en = GameObject.Find ("English");
		Score = GameObject.Find ("Score");
		word = GameObject.FindGameObjectsWithTag ("Word");
		Flip = GameObject.Find ("Flip Parent");
		rolling ();
		 //a = GameObject.Find ("WinText");
		//a.SetActive (false);
		//particle.SetActive (false);
		ParticleSystem.EmissionModule em = system.emission;
		em.enabled = false;
		WinPanel.SetActive (false);
		isWin = false;
		if (GameObject.FindGameObjectWithTag("Music") == null) {
			Instantiate (music);
		}
		source = GetComponent<AudioSource> ();
		source.clip = clip;
		source.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			//setactive true
			ParticleSystem.EmissionModule em = system.emission;
			em.enabled = true;
		}
		else {
			//setactive false
			ParticleSystem.EmissionModule em = system.emission;
			em.enabled = false;
		}
		if (id.GetComponent<Language> ().answer == id.GetComponent<Language> ().KeyAnswer &&
			en.GetComponent<Language> ().answer == en.GetComponent<Language> ().KeyAnswer) {
			revertToNormal ();
			Flip.SetActive (false);
			Flip.SetActive (true);
			if (!isWin) {
				Debug.Log ("Instantiate Bubble");
				Instantiate (TrueEffects, GameObject.Find ("Picture Location").transform.position, Quaternion.identity);
				Score.GetComponent <Score> ().nilai++;
				Score.GetComponent <Score> ().ScoreToString.text = Score.GetComponent <Score> ().nilai + "/10";
			}

		
			if (Score.GetComponent <Score> ().nilai < Picture.Length) {
				
				rolling ();
			} else {
				
				//a.SetActive (true);
				if (!isWin) {
					if (GameObject.FindGameObjectWithTag("Music") != null) {
						Destroy ((GameObject.FindGameObjectWithTag("Music").gameObject));
					}
					playSound ();
					Debug.Log ("You Win");
					WinPanel.SetActive (true);
					isWin = true;

				}

			}
		}
		else {
			
		}
	}
	void OnMouseDown()
	{
		//check Answer

	}
	void revertToNormal ()
	{	
		id.GetComponent <TextMesh>().text = "Indonesia";
		en.GetComponent <TextMesh>().text = "English";
		Destroy (GameObject.FindGameObjectWithTag ("Animals"));
		usedValues.Clear ();
		usedAnswers.Clear ();
	}
	void rolling ()
	{
		//roll gambar
		int val = Random.Range(0,Picture.Length);
		while(usedValuePictures.Contains(val))
		{
			val = Random.Range(0,Picture.Length);
		}
		Instantiate (Picture [val], GameObject.Find ("Picture Location").transform.position, Quaternion.identity, GameObject.Find ("AnimalParent").transform);
		usedValuePictures.Add (val);
		//Kotak jawaban mengambil kunci jawaban
		GameObject [] Language = GameObject.FindGameObjectsWithTag("Language");
		for (int x = 0; x < Language.Length; x++) {
			if (Language [x].GetComponent<Language> ().bahasa == "id") {
				Language[x].GetComponent <Language> ().answer = Picture[val].GetComponent<Picture> ().id;
				Language[x].GetComponent <TextMesh> ().text = Picture[val].GetComponent<Picture> ().id;
				Language[x].GetComponent<Language>().KeyAnswer = Picture[val].GetComponent<Picture> ().id;
			}
			else if (Language[x].GetComponent<Language>().bahasa == "en")
				Language[x].GetComponent<Language>().KeyAnswer =  Picture[val].GetComponent<Picture> ().en;
		}
		//tentukan english taruh di mana
		int english = Random.Range (0,word.Length);
		usedValues.Add (english);
		// ambil english dan taruh di tempat tsb
		word[english].GetComponent<word>().Animal =Picture [val].GetComponent <Picture>().en;
		word [english].GetComponent<TextMesh> ().text = Picture [val].GetComponent <Picture> ().en;
		usedAnswers.Add (word [english].GetComponent<word> ().Animal);
		/*//tentukan indonesia taruh di mana
		int indonesia = Random.Range (0,4);
		while(usedValues.Contains(indonesia))
		{
			indonesia = Random.Range(0,4);
		}
		usedValues.Add (indonesia);
		// ambil indonesia dan taruh di tempat tsb
		word[indonesia].GetComponent<word>().Animal =Picture [val].GetComponent <Picture>().id;
		word [indonesia].GetComponent<TextMesh> ().text = Picture [val].GetComponent <Picture> ().id;
		usedAnswers.Add (word [indonesia].GetComponent<word> ().Animal);*/
		//kotak 2

		//kotak 3
		rollOtherBox();
		rollOtherBox ();
		//kotak 4
	}
	void rollOtherBox()
	{
		//pilih kotak
		int kotakKetiga = Random.Range (0,word.Length);
		while(usedValues.Contains(kotakKetiga))
		{
			kotakKetiga = Random.Range(0,word.Length);
		}
		usedValues.Add (kotakKetiga);
		//pilih jawaban
		int jawabanKetiga = Random.Range (0, AnimalList.Length);
		while(usedAnswers.Contains(AnimalList[jawabanKetiga]))
		{
			jawabanKetiga = Random.Range(0,AnimalList.Length);
		}
		word [kotakKetiga].GetComponent<word> ().Animal = AnimalList [jawabanKetiga];
		word [kotakKetiga].GetComponent<TextMesh> ().text = word [kotakKetiga].GetComponent<word> ().Animal;
		usedAnswers.Add (word [kotakKetiga].GetComponent<word> ().Animal);

	}
}
