using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string playGameLevel;

	public void PlayGame()
	{
		Application.LoadLevel(playGameLevel);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
