﻿using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	public static int Score {get ; set;}
	public static int Best = 0;
	public static bool SpawnBirds;
	private bool gameStart;
	public tk2dTextMesh currentScore;
	public tk2dTextMesh bestScore;
	public tk2dTextMesh startText;
	public GameObject StartObject;
	// Use this for initialization
	void Start () {
		gameStart = true;
		SpawnBirds = false;
		if(PlayerPrefs.HasKey("Best"))
		{
			Best = PlayerPrefs.GetInt("Best");
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if(gameStart)
		{
			if(Input.GetMouseButtonUp(0))
			{
				StartObject.SetActive(false);
				SpawnBirds = true;
			}
		}
		if(Score >= Best)
		{
			Best = Score;
		}
		currentScore.text = "Score: " + Score.ToString();
		bestScore.text = "Best: " + Best.ToString();
	
	}

	public static void GameOver()
	{
		PlayerPrefs.SetInt("Best", Best);
		SpawnBirds = false;
		Application.LoadLevel("Game");
	}
}