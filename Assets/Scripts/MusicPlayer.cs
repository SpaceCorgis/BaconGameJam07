using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization
	public static bool MusicPlaying = false;
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void PlayMusic()
	{
		if(!MusicPlaying)
		{
			audio.Play();
			MusicPlaying = true;
		}
	}
}
