

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {
	public static GUIManager instance;

	public GameObject gameOverPanel;
	public Text yourScoreTxt;
	public Text highScoreTxt;

	public Text scoreTxt;
	public Text moveCounterTxt;
	private int moveCounter;

	private int score;
	public int Score
	{
		get
		{
			return score;
		}

		set
		{
			score = value;
			scoreTxt.text = score.ToString();
		}
	}

	public int MoveCounter
	{
		get
		{
			return moveCounter;
		}

		set
		{
			moveCounter = value;
			moveCounterTxt.text = moveCounter.ToString();
		}
	}

	void Awake() {
		instance = GetComponent<GUIManager>();
		moveCounter = 60;
		moveCounterTxt.text = moveCounter.ToString();

	}

	// Show the game over panel
	public void GameOver() {
		GameManager.instance.gameOver = true;

		gameOverPanel.SetActive(true);

		if (score > PlayerPrefs.GetInt("HighScore")) {
			PlayerPrefs.SetInt("HighScore", score);
			highScoreTxt.text = "New Best: " + PlayerPrefs.GetInt("HighScore").ToString();
		} else {
			highScoreTxt.text = "Best: " + PlayerPrefs.GetInt("HighScore").ToString();
		}

		yourScoreTxt.text = score.ToString();
	}

}
