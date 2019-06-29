using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Enter : MonoBehaviour {public int score;
	public List <int> usedSets = new List <int> ();//supaya set tidak diulang
	public List <int> usedBox = new List <int> ();//supaya tidak diulang boxnya
	public List <int> usedAns = new List <int> ();//supaya tidak diulang jawabannya
	public GameObject[] ChainValue0;
	public GameObject[] ChainValue1;
	public GameObject[] ChainValue2;
	public GameObject[] ObjectAnswer;
	public GameObject [] AnswerBox;
	public GameObject [] AnimalSpawnBox;
	public GameObject particle;
	public GameObject WinPanel;
	public Text ScoreText;
	public GameObject benarEffects;
	public bool isWin;
	public GameObject hold;
	public Vector2 mouseStartPos;
	public int decision;
	public GameObject []JawabanYangSudahDitaruh;
	public List<GameObject> DroppedObject = new List<GameObject> ();
	public GameObject music;
	//=======================
	public AudioClip clip;
	private AudioSource source;
	//========================
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
	//==============================
	// Use this for initialization
	void Start () {
		Debug.Log ("Jalan Level2Enter");
		score = 0;
		ObjectAnswer = new GameObject[3];
		AnswerBox = GameObject.FindGameObjectsWithTag ("AnsBox");
		AnimalSpawnBox = GameObject.FindGameObjectsWithTag ("Animals");
		rolling ();
		ScoreText = GameObject.Find ("Score").GetComponent <Text> ();
		//particle.SetActive (false);
		ParticleSystem.EmissionModule em = system.emission;
		em.enabled = false;
		WinPanel.SetActive (false);
		isWin = false;
		ScoreText.text = "Skor : " + score + "/" + ChainValue0.Length;
		source = GetComponent<AudioSource> ();
		source.clip = clip;
		source.playOnAwake = false;
		if (GameObject.FindGameObjectWithTag("Music") == null) {
			Instantiate (music);
		}
	}
	void playSound()
	{
		source.PlayOneShot (clip);
		source.loop = false;
	}
	void setJawabanYangSudahDitaruh()
	{	
		JawabanYangSudahDitaruh = GameObject.FindGameObjectsWithTag ("DragableAns");
		for (int x = 1; x< JawabanYangSudahDitaruh.Length; x++)
		{
			for (int y = 0; y < x; y++) {
				if (JawabanYangSudahDitaruh [x].GetComponent<Level2Ans> ().ChainValue < JawabanYangSudahDitaruh [y].GetComponent<Level2Ans> ().ChainValue) {
					GameObject temp = null;
					temp = JawabanYangSudahDitaruh [x];
					JawabanYangSudahDitaruh [x] = JawabanYangSudahDitaruh [y];
					JawabanYangSudahDitaruh [y] = temp;
				}
			}
		}
		//put to list
		for (int x = 0; x < JawabanYangSudahDitaruh.Length; x++) {
			DroppedObject.Add (JawabanYangSudahDitaruh [x]);
		}
	}

	// Update is called once per frame
	void Update () {
		setJawabanYangSudahDitaruh ();
			if (Conditions ()) {
				Debug.Log ("Update Enter");

				revertToNormal ();

			if (!isWin) {
				for (int x = 0; x < AnswerBox.Length; x++) {
					Instantiate (benarEffects, AnswerBox[x].transform.position, Quaternion.identity);
				}
				score++;
				ScoreText.text = score + "/" + ChainValue0.Length;
				}	
				if (score < ChainValue0.Length) {
					
						rolling ();
					}
				else {
					if (!isWin) {
					if (GameObject.FindGameObjectWithTag("Music") != null) {
						Destroy ((GameObject.FindGameObjectWithTag("Music").gameObject));
							}
					playSound ();
						//ScoreText.text = "You Win";
						WinPanel.SetActive (true);
					isWin = true;
					}
				}
			}
		if (Input.GetMouseButton (0)) {
			//setactive true
			//particle.SetActive(true);
			ParticleSystem.EmissionModule em = system.emission;
			em.enabled = true;
		}
		else {
			//setactive false
			//particle.SetActive(false);
			ParticleSystem.EmissionModule em = system.emission;
			em.enabled = false;
		}
	}
	void OnMouseDown()
	{	

	}
	public bool Conditions ()
	{	decision = 0;
		Debug.Log ("Run Decision");
		// pastikan chain value next = this chain value +1;
		for (int x = 0; x < JawabanYangSudahDitaruh.Length-1; x++) {
			Debug.Log ("Run Decision for");
			//if (ObjectAnswer [x].GetComponent <Level2Ans> ().next != null) {
			if (JawabanYangSudahDitaruh [x] != null && JawabanYangSudahDitaruh [x + 1] != null&&!isWin) {
				if (GameObject.ReferenceEquals (JawabanYangSudahDitaruh[x].GetComponent <Level2Ans>().next, JawabanYangSudahDitaruh[x+1])) {
					Debug.Log ("Run Decision true");	
					decision++;

				}
			}
			//}

		}
		if (decision >= 2) {
			return true;		
		}
		else {
			return false;
		}
	}
	void revertToNormal()
	{	
		
		for (int x = 0; x < AnswerBox.Length; x++) {
			AnswerBox [x].GetComponent <Level2Box> ().AnswerObject = null;
			AnswerBox [x].GetComponent <Level2Box> ().playerAnswer = -1;

		}
		GameObject[] toDestroy = GameObject.FindGameObjectsWithTag ("DragableAns");
		for (int x = 0; x < toDestroy.Length; x++) {
			DroppedObject.Remove (toDestroy [x]);
			JawabanYangSudahDitaruh [x] = null;
			Destroy (toDestroy [x]);
		}
		usedBox.Clear ();
		usedAns.Clear ();
	}
	void rolling ()
	{
		//roll buat nentuin set of chain value
		int ChainSet = Random.Range (0, ChainValue0.Length);
		while (usedSets.Contains (ChainSet)) {
			ChainSet = Random.Range (0, ChainValue0.Length);
		}
			
		ObjectAnswer [0] = ChainValue0 [ChainSet];
		ObjectAnswer [1] = ChainValue1 [ChainSet];
		ObjectAnswer [2] = ChainValue2 [ChainSet];
		usedSets.Add (ChainSet);

		//roll buat nentuin setiap item set ditaruh di box mana?
		rollbox();
		rollbox();
		rollbox();

	}
	void rollbox()
	{
		//pilih kotak
		int boxChoice = Random.Range (0,AnimalSpawnBox.Length);
		while(usedBox.Contains(boxChoice))
		{
			boxChoice = Random.Range(0,AnimalSpawnBox.Length);
		}
		usedBox.Add (boxChoice);
		//pilih jawaban
		int ansChoice = Random.Range (0, ObjectAnswer.Length);
		while (usedAns.Contains (ansChoice)) {
			ansChoice = Random.Range (0, ObjectAnswer.Length);
		}
		usedAns.Add (ansChoice);
		//taruh jawaban
		GameObject children = Instantiate (ObjectAnswer[ansChoice], AnimalSpawnBox[boxChoice].transform.position,Quaternion.identity,GameObject.Find ("ParentObject").transform);
		children.transform.position = children.transform.position + new Vector3 (0f, 0f, 5f);
	}


}
