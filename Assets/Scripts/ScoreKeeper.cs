using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	public static int Score {get ; set;}
	public static int Best = 0;
	public static int BestTrees = 0;
	public static bool SpawnBirds;
	public static bool canScore;
	private bool gameStart;
	public tk2dTextMesh currentScore;
	public tk2dTextMesh bestScore;
	public tk2dTextMesh startText;
	public GameObject StartObject;
	public static AudioSource AudioS;
	public LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		canScore = true;
		gameStart = true;
		SpawnBirds = false;
		if(PlayerPrefs.HasKey("Best"))
		{
			Best = PlayerPrefs.GetInt("Best");
		}
		if(PlayerPrefs.HasKey("BestTrees"))
		{
			BestTrees = PlayerPrefs.GetInt("BestTrees");
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if(gameStart)
		{
			if(Input.GetMouseButtonDown(0))
			{
				StartObject.SetActive(false);
				SpawnBirds = true;
				canScore = true;
			}
		}
		if(levelManager.GameType == "Birds")
		{
			if(Score >= Best)
			{
				Best = Score;
			}
			currentScore.text = "Score: " + Score.ToString();
			bestScore.text = "Best: " + Best.ToString();
		}
		else if(levelManager.GameType == "Trees")
		{
			if(Score >= BestTrees)
			{
				BestTrees = Score;
			}
			currentScore.text = "Score: " + Score.ToString();
			bestScore.text = "Best: " + BestTrees.ToString();
		}
	
	}

	public static void GameOver()
	{
		canScore = false;
		Score = 0;
		PlayerPrefs.SetInt("Best", Best);
		PlayerPrefs.SetInt("BestTrees", BestTrees);
		SpawnBirds = false;
		Application.LoadLevel("Title");
	}
}
