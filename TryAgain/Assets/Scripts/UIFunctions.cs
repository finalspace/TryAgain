using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour {

	#region Variables
	//public
	[SerializeField]
	public bool gameStarted = false;

	//private
	[SerializeField]
	private int score;
	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private Button settingsButton;
	[SerializeField]
	private Button shopButton;
	[SerializeField]
	private Button leaderboardButton;
	[SerializeField]
	private Text titleText;
	[SerializeField]
	private Button tapToPlayButton;
	[SerializeField]
	private Button restartButton;
	[SerializeField]
	private Button homeButton;
	[SerializeField]
	private Button twitterButton;
	[SerializeField]
	private Button achievementButton;
	[SerializeField]
	private Text endScoreText;
	[SerializeField]
	private Text endBestScoreText;

	private bool onOff;

	#endregion

	#region UnityFunctions

	void Start()
	{
		Debug.Log (PlayerPrefs.GetInt ("Score"));
		InvokeRepeating ("UpdateScore", 1.0f, 1.0f);
	}

	void Update () 
	{
		if (!gameStarted) 
		{
			if (Input.GetKey (KeyCode.O) || Input.GetKey (KeyCode.P))
				PlayGame ();
		}
	}

	#endregion 

	public void SettingsFunctions()
	{
	}

	public void ShopFunctions()
	{
	}

	public void PlayGame()
	{
		twitterButton.gameObject.SetActive (false);
		achievementButton.gameObject.SetActive (false);
		scoreText.gameObject.SetActive (true);
		settingsButton.gameObject.SetActive (false);
		shopButton.gameObject.SetActive (false);
		leaderboardButton.gameObject.SetActive (false);
		titleText.gameObject.SetActive (false);
		tapToPlayButton.gameObject.SetActive (false);
		gameStarted = true;
	}

	private void UpdateScore()
	{
		if (gameStarted) 
		{
			score++;
			scoreText.text = "" + score;
		}
	}

	public void RestartGame()
	{
		SceneManager.LoadScene ("MobileGameLevel");
	}

	public void HomeFunction()
	{
		SceneManager.LoadScene ("MobileGameLevel");
	}

	public void MuteGame()
	{
		onOff = !onOff;

		if (onOff == true) {
			PlayerPrefs.SetInt ("Audio", 0);
		} else {
			PlayerPrefs.SetInt ("Audio", 1);
		}

		if (PlayerPrefs.GetInt ("Audio") == 0) {
			AudioListener.volume = 100;
		} else {
			AudioListener.volume = 0;
		}
	}

	public void GameEnded()
	{
		if (PlayerPrefs.GetInt ("Score") < score) 
		{
			PlayerPrefs.SetInt ("Score", score);
		}
		endScoreText.text = "Score:                   " + score;
		endBestScoreText.text = "Best Score:          " + PlayerPrefs.GetInt("Score");
		endScoreText.gameObject.SetActive (true);
		endBestScoreText.gameObject.SetActive (true);
		scoreText.gameObject.SetActive (false);
		restartButton.gameObject.SetActive (true);
		homeButton.gameObject.SetActive (true);
		gameStarted = false;
		PlayerPrefs.Save ();
	}

}