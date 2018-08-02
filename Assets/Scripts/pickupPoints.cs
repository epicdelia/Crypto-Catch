using UnityEngine;
using System.Collections;

public class pickupPoints : MonoBehaviour {

	public int scoreToGive;

	private ScoreManager theScoreManager;

	private AudioSource coinSound;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager>();

		coinSound = GameObject.Find ("CoinSound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //When something enters trigger
	void OnTriggerEnter2D(Collider2D other)
	{
        //Make sure that the colliding item is actually Satoshi
		if(other.gameObject.name == "Player")
		{
			theScoreManager.AddScore(scoreToGive);
			gameObject.SetActive(false);

			if(coinSound.isPlaying)
			{
				coinSound.Stop ();
				coinSound.Play ();
			} else {
				coinSound.Play();
			}
		}
	}
}
