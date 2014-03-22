using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	public static int Score {get ; set;}
	public static int Best = 0;
	public static int BestTrees = 0;
	public static bool SpawnBirds;
	public static bool canScore;
	public bool gameStart;
	public bool gameEnd;
	public tk2dTextMesh currentScore;
	public tk2dTextMesh bestScore;
	public tk2dTextMesh startText;
	public GameObject StartObject;
	public static AudioSource AudioS;
	public LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		Score = 0;
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
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				var xpoint = ray.GetPoint(1).x;
				var ypoint = ray.GetPoint(1).y;
				//Debug.Log(xpoint);
				//Debug.Log(ypoint);
				if(xpoint <= -0.3875 && ypoint >= 0.64375)
				{
					Debug.Log("hit back");
					Application.LoadLevel("Select");
					return;
				}
			}
			if(Input.GetMouseButtonDown(0))
			{
				StartObject.SetActive(false);
				SpawnBirds = true;
				canScore = true;
				gameStart = false;
			}
		}
		if(gameEnd)
		{
			if(Input.GetMouseButtonDown(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				var xpoint = ray.GetPoint(1).x;
				var ypoint = ray.GetPoint(1).y;
				//Debug.Log(xpoint);
				//Debug.Log(ypoint);
				if(xpoint <= -0.3875 && ypoint >= 0.64375)
				{
					//Debug.Log("hit back");
					Application.LoadLevel("Select");
					return;
				}
			}
			if(Input.GetMouseButtonDown(0))
			{
				Score = 0;
				gameEnd = false;
				Application.LoadLevel("Game");
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

	public void GameOver()
	{
		gameEnd = true;
		startText.text = "Replay?";
		StartObject.SetActive(true);
		canScore = false;
		//Score = 0;
		PlayerPrefs.SetInt("Best", Best);
		PlayerPrefs.SetInt("BestTrees", BestTrees);
		SpawnBirds = false;

		//Application.LoadLevel("Title");
	}
}
