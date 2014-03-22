using UnityEngine;
using System.Collections;

public class OnClick : MonoBehaviour {

	public Rigidbody2D seed;
	public float factor = 1500;
	public tk2dSpriteAnimator windRight;
	public GameObject windRightObject;
	public tk2dSpriteAnimator windLeft;
	public GameObject windLeftObject;
	// Use this for initialization
	void Start () {
		windRightObject.SetActive(false);
		windLeftObject.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {
		if(ScoreKeeper.SpawnBirds)
		{
			if(Input.GetMouseButtonDown(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				var point = ray.GetPoint(1).x;
				if(point > 0)
				{
					windRightObject.SetActive(true);
					windRight.Play();
					windRight.AnimationCompleted = WindRightCompleted;
					seed.AddForce(new Vector3(-1,0,0).normalized * factor);
				}
				else
				{
					windLeftObject.SetActive(true);
					windLeft.Play();
					windLeft.AnimationCompleted = WindLeftCompleted;
					seed.AddForce(new Vector3(1,0,0).normalized * factor);
				}

			}
		}
	}
	void WindRightCompleted(tk2dSpriteAnimator sprite, tk2dSpriteAnimationClip clip)
	{
		windRightObject.SetActive(false);
	}

	void WindLeftCompleted(tk2dSpriteAnimator sprite, tk2dSpriteAnimationClip clip)
	{
		windLeftObject.SetActive(false);
	}
}
