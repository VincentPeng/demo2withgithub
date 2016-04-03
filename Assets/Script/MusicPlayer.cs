using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {


	static MusicPlayer instance = null;
	
	void Awake () {
		Debug.Log ("MusicPlayer Awake " + GetInstanceID ());
		if(instance == null) {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		} else {
			Debug.Log ("Music player GameObject self-destroy");
			Destroy (gameObject);
		}
	}
	
	// Use this for initialization
	void Start () {
		Debug.Log ("MusicPlayer Start " + GetInstanceID ());
	
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
