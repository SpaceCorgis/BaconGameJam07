using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject birdSM;
	public GameObject birdLG;
	public float timerStart = 1.5f;
	public float birdSpeedSM = -1f;
	public float birdSpeedLG = -1;
	public LevelManager levelManager;
	private float timer;
	Vector2 spawnLocation;

	//ForTrees
	public GameObject Branches;
	public float timerStartBranches;
	public float BranchesSpeed;
	private float timerBranches;
	Vector2 branchesSpawnLocation;

	// Use this for initialization
	void Start () {
		timer = timerStart;
		timerBranches = timerStartBranches;
		levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(ScoreKeeper.SpawnBirds)
		{
			if(levelManager.GameType == "Birds")
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
			else if(levelManager.GameType == "Trees")
			{
				timerBranches -= Time.deltaTime;
				if(timerBranches <=0)
				{
					branchesSpawnLocation = new Vector2(Random.Range(-0.34f,0.34f),1);
					GameObject spawnedBranch = (GameObject)Instantiate(Branches,branchesSpawnLocation,Quaternion.identity);
					spawnedBranch.rigidbody2D.velocity = new Vector2(0, BranchesSpeed);
					timerBranches = timerStartBranches;
				}
			}
		}
	
	}
}
