/*=============================================================================
 |  Class: Powerups
 |  Author:  Delia Lazarescu
 |  Description: Class to control the player power ups
 *===========================================================================*/
using UnityEngine;
using System.Collections;

public class Powerups : MonoBehaviour {

	public bool doublePoints;
	public bool safeMode;

	public float powerupLength;

	private PowerupManager thePowerupManager;

	// Use this for initialization
	void Start () {
		thePowerupManager = FindObjectOfType<PowerupManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			thePowerupManager.ActivatePowerup(doublePoints, safeMode, powerupLength);
		}
		gameObject.SetActive(false);
	}
}
