using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization
	public static bool MusicPlaying = false;
	void Start () {
		if(MusicPlaying)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		if(!MusicPlaying)
		{
			audio.Play();
			MusicPlaying = true;
		}

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
