using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace GameTemplate_UltimateSpaceShooterGamesMaker
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager instance;
		public bool OnSpeedUp;
		public bool miniBossActive = false;
		public bool miniBossDestroyed = false;
		public bool isGameActive = false;
		public bool isShakeActive = false;
		public bool AllowMiniBossMovement = false;

		public int score = 0;
		public int highScore;
		public TextMeshProUGUI highScoreText;

		public List<GameObject> powerUpList;

		public UIManager UiManager;
		public PlayerController playerController;
		public EnemySpawnManager enemySpawnManager;

		public UnityEvent SpeedPowerUp;

		#region Singleton

		void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			else
			{
				Destroy(gameObject);
			}

			UiManager.InitialGame();
			highScore = PlayerPrefs.GetInt("HighScore", 0);
			highScoreText.text += highScore.ToString();
		}

		#endregion

		public void StartGame()
		{
			isGameActive = true;
			playerController.StartGame();
			enemySpawnManager.StartGame();
			StartCoroutine(Timer());
			Debug.Log(highScore);
		}

		public void ExitGame()
		{
			// Check the platform and quit the application accordingly
			#if UNITY_EDITOR
						UnityEditor.EditorApplication.isPlaying = false; // Exit play mode in Unity Editor
			#elif UNITY_STANDALONE
			            Application.Quit(); // Quit the application on Windows or Mac
			#elif UNITY_ANDROID
			            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer")
			                .GetStatic<AndroidJavaObject>("currentActivity");
			            activity.Call("finishAffinity"); // Completely stop the application on Android
			#endif
		}
		public void GameOver()
		{
			isGameActive = false;
			UiManager.GameOver();
		}

		public void UpdateScore(int amount)
		{
			score += amount;
			if (score > highScore)
			{
				highScore = score;
				PlayerPrefs.SetInt("HighScore", highScore);
			}
			UiManager.scoreText.text = score.ToString();
		}

		IEnumerator Timer()
		{

			for (int i = 0; i < powerUpList.Count; i++)
			{
				yield return new WaitForSeconds(Random.Range(10, 11));
				GameObject powerUpObject =
					Instantiate(powerUpList[i], new Vector2(Random.Range(-2.3f, 2.3f), Random.Range(3.0f, -3.0f)),
						powerUpList[i].transform.rotation);

			}

			isShakeActive = true;
			AllowMiniBossMovement = true;
			yield return new WaitForSeconds(10.0f);
			ActivateMiniBoss();
			AllowMiniBossMovement = false;
		}

		public void ActivateMiniBoss()
		{
			miniBossActive = true;
		}

	}
}
