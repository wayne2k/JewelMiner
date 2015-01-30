using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace RollRoti.JewelMiner
{
	public class ScoreManager : MonoBehaviour 
	{
		public int score = 0;
		public int targetScore = 400;
		public Text scoreText;
		public Text timeText;
		public int timePerLevel = 30;

		public GameObject youWon;
		public GameObject gameOver;

		float _clockSpeed = 1f;

		void Awake ()
		{
			scoreText.text = ("score: " + score + " / " + targetScore);
			InvokeRepeating ("Clock", 0f, _clockSpeed);
		}

		void Clock ()
		{
			timePerLevel--;
			timeText.text = ("Time: " + timePerLevel);
			if (timePerLevel <= 0) 
			{
				CheckGameOver ();
			}
		}

		void CheckGameOver ()
		{
			if (score >= targetScore)
			{
				Time.timeScale = 0f;
				youWon.SetActive (true);
			}
			else
			{
				Time.timeScale = 0f;
				gameOver.SetActive (true);
			}
		}

		public void AddPoints (int pointsScored)
		{
			score += pointsScored;
			scoreText.text = ("score: " + score + " / " + targetScore);
		}
	}
}