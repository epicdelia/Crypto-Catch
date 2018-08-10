/*=============================================================================
 |  Class: Pause Menu
 |  Author:  Delia Lazarescu
 |  Description: Menu for when player wished to pause the game and return
 *===========================================================================*/
using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;

	public GameObject pauseMenu;

    //use time function in unity to make things easier 
	public void PauseGame()
	{
		Time.timeScale = 0f;
		pauseMenu.SetActive(true);
	}

	public void ResumeGame()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
	}
	
    //reset the game manager when the game is restarted 
	public void RestartGame()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
		FindObjectOfType<GameManager>().Reset();
	}
	
    //no levels but using this function is still easiest way to quit to main menu
	public void QuitToMain()
	{
		Time.timeScale = 1f;
		Application.LoadLevel(mainMenuLevel);
	}
}
