using UnityEngine;
using System.Collections;

public class Seed : MonoBehaviour {
	public tk2dSpriteAnimator _anim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(rigidbody2D.velocity.x);
		if(rigidbody2D.velocity.x >= -0.07f && rigidbody2D.velocity.x <= 0.07f)
		{
			_anim.Play("seed/Idle");
		}
		if(rigidbody2D.velocity.x > 0.07f)
		{
			_anim.Play("seed/Right");
		}
		else if(rigidbody2D.velocity.x < -0.07f)
		{
			_anim.Play("seed/Left");
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Bird")
		{
			DestroyObject(gameObject);
			ScoreKeeper.GameOver();
		}
	}

	void OnBecameInvisible()
	{
		ScoreKeeper.GameOver();
		DestroyObject(gameObject);
	}
}
