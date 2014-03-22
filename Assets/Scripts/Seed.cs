using UnityEngine;
using System.Collections;

public class Seed : MonoBehaviour {
	public tk2dSpriteAnimator _anim;
	public SFXPlayer sfxPlayer;
	public ScoreKeeper scoreKeeper;
	// Use this for initialization
	void Start () {
		sfxPlayer = GameObject.Find("SFXPlayer").GetComponent<SFXPlayer>();
		scoreKeeper = GameObject.Find("Managers").GetComponent<ScoreKeeper>();
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
			DestroyObject(collision.gameObject);
			scoreKeeper.GameOver();
		}
		if(collision.gameObject.tag == "Tree")
		{
			sfxPlayer.playDeath();
			DestroyObject(gameObject);
			DestroyObject(collision.gameObject);
			scoreKeeper.GameOver();
		}
	}

	void OnBecameInvisible()
	{
		if(!scoreKeeper.gameStart && !scoreKeeper.gameEnd)
		{
			sfxPlayer.playDeath();
			scoreKeeper.GameOver();
			DestroyObject(gameObject);
		}
	}
}
