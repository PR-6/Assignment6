using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
	public Text pausedText;
	public GameObject playButton;
	public GameObject restartButton;
	public GameObject menuButton;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			}
			else if (Time.timeScale == 0)
			{
				Debug.Log("high");
				Time.timeScale = 1;
				hidePaused();
			}
		}

	}

	public void Reload()
	{
		pauseControl();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void mainMenu()
    {
		pauseControl();
		SceneManager.LoadScene(0);
	}

	public void pauseControl()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			hidePaused();
		}
	}

	public void showPaused()
	{
		pausedText.gameObject.SetActive(true);
		playButton.gameObject.SetActive(true);
		restartButton.gameObject.SetActive(true);
		menuButton.gameObject.SetActive(true);
	}

	public void hidePaused()
	{
		pausedText.gameObject.SetActive(false);
		playButton.gameObject.SetActive(false);
		restartButton.gameObject.SetActive(false);
		menuButton.gameObject.SetActive(false);

	}
}
