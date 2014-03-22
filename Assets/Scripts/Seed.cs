using UnityEngine;
using System.Collections;

public class Seed : MonoBehaviour {
	public float speed = 10.0f;
	public tk2dSprite sprite;
	private bool blue = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//var translation = Input.GetAxis("Horizontal") * speed;
		//translation *= Time.deltaTime;
		//transform.Translate(translation, 0 , 0);
		if(Input.GetMouseButtonDown(0))
		{

		}
		
		
	}
}
