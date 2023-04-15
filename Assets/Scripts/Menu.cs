using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public static bool GameIsPaused = false; 
	public GameObject pauseMenuUI;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			if (GameIsPaused) 
			{
				ResumeGame();
			} 
			else 
			{
				PauseGame();
			}
		}
	}

	public void ResumeGame()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void PauseGame ()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void PlayGame ()
	{
		SceneManager.LoadScene("MyGame");
	}

	public void LoadMenu ()
	{
		SceneManager.LoadScene("Main Menu");
	}

	public void QuitGame ()
	{
		Application.Quit();
	}
}
