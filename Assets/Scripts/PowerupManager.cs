/*=============================================================================
 |  Class: Powerup Manager 
 |  Author:  Delia Lazarescu
 |  Description: This class controls the power ups
 *===========================================================================*/
using UnityEngine;
using System.Collections;

public class PowerupManager : MonoBehaviour {

	private bool doublePoints;
	private bool safeMode;
	
	private bool powerupActive;

	private float powerupLengthCounter;

	private ScoreManager theScoreManager;
	private PlatformGenerator thePlatformGenerator;

	private float normalPointsPerSecond;
	private float spikeRate;

	// Use this for initialization
	void Start () {
        //initialize variables 
		theScoreManager = FindObjectOfType<ScoreManager>();
		thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
	}
	
	// Update is called once per frame
	void Update () {

        //if player currently has power up 
		if(powerupActive)
		{
			powerupLengthCounter -= Time.deltaTime;

			if(doublePoints)
			{
				theScoreManager.pointsPerSecond = normalPointsPerSecond * 2.75f;
				theScoreManager.shouldDouble = true;
			}

			if(safeMode)
			{
				thePlatformGenerator.randomSpikeThreshold = 0f;
			}

			if(powerupLengthCounter <= 0)
			{
				theScoreManager.pointsPerSecond = normalPointsPerSecond;
				theScoreManager.shouldDouble = false;

				thePlatformGenerator.randomSpikeThreshold = spikeRate;


				powerupActive = false;
			}
		}
	}

	public void ActivatePowerup(bool points, bool safe, float time)
	{
		doublePoints = points;
		safeMode = safe;
		powerupLengthCounter = time;

		normalPointsPerSecond = theScoreManager.pointsPerSecond;
		spikeRate = thePlatformGenerator.randomSpikeThreshold;

		powerupActive = true;
	}
}
