using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject bird;
	public float timerStart = 1.5f;
	public float birdSpeed = -0.5f;
	private float timer;
	Vector2 spawnLocation;
	// Use this for initialization
	void Start () {
		timer = timerStart;
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer <= 0)
		{
			spawnLocation = new Vector2(Random.Range(-0.5f, 0.5f),1);

			GameObject spawnedBird = (GameObject)Instantiate(bird, spawnLocation, Quaternion.identity);
			spawnedBird.rigidbody2D.velocity = new Vector2(0,birdSpeed);
			timer = timerStart;
		}
	
	}
}
