/*=============================================================================
 |  Class: Coin Generator 
 |  Author:  Delia Lazarescu
 |  Description: Script that is attached the all the coins, used to add Points to the score when item picked up
 *===========================================================================*/

using UnityEngine;
using System.Collections;

public class pickupPoints : MonoBehaviour {
    
	public int scorePoints;

	private ScoreManager theScoreManager;

	private AudioSource coinSound;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager>();

		coinSound = GameObject.Find ("CoinSound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame, no need here 
	void Update () {
	
	}

    //When something enters trigger
	void OnTriggerEnter2D(Collider2D other)
	{
        
        //Make sure that the colliding item is actually Satoshi
		if(other.gameObject.name == "Player")
		{
            //add score to total then deactivate object to save memory 
            theScoreManager.AddScore(scorePoints);
			gameObject.SetActive(false);

            //don't overload player's ears with too many sounds by only playing one at a time 
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
