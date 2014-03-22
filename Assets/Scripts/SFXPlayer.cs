using UnityEngine;
using System.Collections;

public class SFXPlayer : MonoBehaviour {

	public AudioClip death;
	public AudioClip branchDeath;
	public LevelManager levelManager;
	// Use this for initialization
	void Start () {
		//levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		DontDestroyOnLoad(gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void playDeath()
	{
		if(levelManager.GameType == "Birds")
		{
			audio.PlayOneShot(death);
		}
		else if(levelManager.GameType == "Trees")
		{
			audio.PlayOneShot(branchDeath);
		}
		//Destroy(gameObject, 2f);
	}
}
