/*=============================================================================
 |  Class: Game Manager 
 |  Author:  Delia Lazarescu
 |  Description: Handles the screens of the game and when to transition to them
 *===========================================================================*/
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public PlayerController thePlayer;
	private Vector3 playerStartPoint;

	private PlatformDestroyer[] platformList;

	private ScoreManager theScoreManager;

	public DeathMenu theDeathScreen;

	// Use this for initialization
	void Start () {
		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;

		theScoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RestartGame()
	{
		theDeathScreen.gameObject.SetActive(true);
		theScoreManager.scoreIncreasing = false;

		thePlayer.gameObject.SetActive(false);

	}

   // used to restart game when player dies 
	public void Reset()
    {
        //show player he died and give options 
		theDeathScreen.gameObject.SetActive(false);

        //destroy all remaining objects by deactivating 
		platformList = FindObjectsOfType<PlatformDestroyer>();
		for(int i = 0; i < platformList.Length; i++)
		{
			platformList[i].gameObject.SetActive(false);
		}
		
        //return player to start and score to 0 
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive(true);
		
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}

}
