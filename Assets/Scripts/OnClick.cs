using UnityEngine;
using System.Collections;

public class OnClick : MonoBehaviour {

	public Rigidbody2D seed;
	float factor = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			var point = ray.GetPoint(1).x;
			if(point > 0)
			{
				seed.AddForce(new Vector3(-1,0,0).normalized * factor);
			}
			else
			{
				seed.AddForce(new Vector3(1,0,0).normalized * factor);
			}

		}
	
	}
}
