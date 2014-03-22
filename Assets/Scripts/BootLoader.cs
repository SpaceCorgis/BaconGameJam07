using UnityEngine;
using System.Collections;

public class BootLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.SetResolution(320,480,true);
		Application.LoadLevel("Title");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
