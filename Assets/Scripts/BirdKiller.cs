﻿using UnityEngine;
using System.Collections;

public class BirdKiller : MonoBehaviour {

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnBecameInvisible()
	{
		DestroyObject(gameObject);
		if(ScoreKeeper.canScore)
		{
			ScoreKeeper.Score += 1;
		}
	}
}
