using UnityEngine;
using System.Collections;

public class Seed : MonoBehaviour {
	public tk2dSpriteAnimator _anim;
	public SFXPlayer sfxPlayer;
	// Use this for initialization
	void Start () {
		sfxPlayer = GameObject.Find("SFXPlayer").GetComponent<SFXPlayer>();
	
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
			sfxPlayer.playDeath();
			DestroyObject(gameObject);
			ScoreKeeper.GameOver();
		}
		if(collision.gameObject.tag == "Tree")
		{
			sfxPlayer.playDeath();
			DestroyObject(gameObject);
			ScoreKeeper.GameOver();
		}
	}

	void OnBecameInvisible()
	{
		sfxPlayer.playDeath();
		ScoreKeeper.GameOver();
		DestroyObject(gameObject);
	}
}
