using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject birdSM;
	public GameObject birdLG;
	public float timerStart = 1.5f;
	public float birdSpeedSM = -1f;
	public float birdSpeedLG = -1;
	private float timer;
	Vector2 spawnLocation;
	// Use this for initialization
	void Start () {
		timer = timerStart;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(ScoreKeeper.SpawnBirds)
		{
			timer -= Time.deltaTime;
			if(timer <= 0)
			{
				spawnLocation = new Vector2(Random.Range(-0.4f, 0.4f),1);

				GameObject spawnedBird;
				int randBird = Random.Range(1,3);
				if(randBird == 1)
				{
					spawnedBird = (GameObject)Instantiate(birdSM, spawnLocation, Quaternion.identity);
					spawnedBird.rigidbody2D.velocity = new Vector2(0,birdSpeedSM);
				}
				else
				{
					spawnedBird = (GameObject)Instantiate(birdLG, spawnLocation, Quaternion.identity);
					spawnedBird.rigidbody2D.velocity = new Vector2(0,birdSpeedLG);
				}


				timer = timerStart;
			}
		}
	
	}
}
