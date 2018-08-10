/*=============================================================================
 |  Class: Coin Generator 
 |  Author:  Delia Lazarescu
 |  Description: Class used to restart the game when player dies 
 *===========================================================================*/
using UnityEngine;

public class DeathMenu : MonoBehaviour {
	
	public string mainMenuLevel;

	public void RestartGame()
	{
		FindObjectOfType<GameManager>().Reset();
	}

	public void QuitToMain()
	{
		Application.LoadLevel(mainMenuLevel);
	}
}
