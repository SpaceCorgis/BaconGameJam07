using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	// Use this for initialization
	[SerializeField] public string GameType ;
	void Start () {
		DontDestroyOnLoad(gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			if(Application.loadedLevelName == "Title")
			{
				Application.LoadLevel("Select");
			}
			else if(Application.loadedLevelName == "Select")
			{
				if(Input.GetMouseButtonDown(0))
				{
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					var point = ray.GetPoint(1).x;
					if(point > 0)
					{
						GameType = "Birds";
						Application.LoadLevel("Game");
					}
					else
					{
						GameType = "Trees";
						Application.LoadLevel("Game");
					}
					Debug.Log(GameType);
				}
			}
			else if(Application.loadedLevelName == "Game")
			{
				return;
			}
		}
	}
}
